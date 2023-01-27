using Mahtan.Assets.Values.Enums;
using Mahtan.Data.Repositories;
using Mahtan.Services;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.Identity.Controllers
{
    [Area(nameof(Identity))]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<Models.User> _signInManager;
        private readonly UserManager<Models.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ISmsService _smsService;

        public AccountController(IUnitOfWork unitOfWork, UserManager<Models.User> userManager,
            SignInManager<Models.User> signInManager, RoleManager<IdentityRole> roleManager,
            ISmsService smsService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _smsService = smsService;
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;

            return View(new AccountViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Register([Bind(Prefix = "RegisterViewModel")] RegisterViewModel registerViewModel, string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new Models.User()
                {
                    UserName = registerViewModel.PhoneNumber,
                    PhoneNumber = registerViewModel.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.User.ToString());

                    return RedirectToAction("ConfirmPhone", new { area = "Identity", controller = "Account", phoneNumber = user.PhoneNumber });
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            if (User.Identity.Name != null)
            {
                var signedUser = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name);
                return await RedirectToUserRoleDefaultView(signedUser, returnUrl);
            }

            ViewData["returnUrl"] = returnUrl;
            return View(new AccountViewModel());
        }

        private async Task<IActionResult> RedirectToUserRoleDefaultView(Models.User signedUser, string returnUrl = null)
        {
            returnUrl ??= await _userManager.IsInRoleAsync(signedUser, Roles.User.ToString()) ? "/User/Profile" : "/Admin/User";
            return LocalRedirect(returnUrl);
        }

        private async Task CreateAndSendNewMobileConfirmCode(Models.User user)
        {
            user.MobileConfirmationCode = new Random().Next(100000, 999999).ToString();
            await _userManager.UpdateAsync(user);
            await _smsService.SendSmsAsync(user.PhoneNumber, user.MobileConfirmationCode.ToString());
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind(Prefix = "LoginViewModel")] LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.PhoneNumber, viewModel.Password, viewModel.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var signedUser = await _signInManager.UserManager.FindByNameAsync(viewModel.PhoneNumber);
                    await _signInManager.RefreshSignInAsync(signedUser);

                    return await RedirectToUserRoleDefaultView(signedUser, returnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, "نام کاربری و/یا کلمه عبور نادرست است");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmPhone(string phoneNumber, string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            var user = await _userManager.FindByNameAsync(phoneNumber);
            if (user == null)
                ModelState.AddModelError(string.Empty, "شماره معتبر نمی باشد.");
            else
                await CreateAndSendNewMobileConfirmCode(user);

            return View(new ConfirmPhoneViewModel { PhoneNumber = phoneNumber });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPhone(ConfirmPhoneViewModel viewModel, string returnUrl)
        {
            var user = await _userManager.FindByNameAsync(viewModel.PhoneNumber);
            if (user == null)
                ModelState.AddModelError(string.Empty, "شماره معتبر نمی باشد.");
            else
            {
                if (viewModel.VerificationCode == user.MobileConfirmationCode)
                {
                    user.PhoneNumberConfirmed = true;
                    await _userManager.UpdateAsync(user);

                    return await RedirectToUserRoleDefaultView(user, returnUrl);
                }
                else
                {
                    ModelState.AddModelError(nameof(viewModel.VerificationCode), "کد وارد شده نادرست می باشد؛ لطفا کد صحیح را وارد کنید.");
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
