using Mahtan.Assets.Extensions;
using Mahtan.Assets.Values.Enums;
using Mahtan.Data.Repositories;
using Mahtan.Services;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Models.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(IUnitOfWork unitOfWork, UserManager<Models.User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var profiles = _unitOfWork.Profiles.Find().AsEnumerable();
            var users = _userManager.Users.AsEnumerable()
                .Select(async u => new UserWithProfile()
                {
                    Username = u.UserName,
                    PhoneNumber = u.PhoneNumber,
                    RegisterDateTime = u.RegisterDateTime.ToShortPersianDate(),
                    FullName = profiles.FirstOrDefault(p => p.Username == u.PhoneNumber)?.FullName,
                    Role = (await _userManager.GetRolesAsync(u)).AsEnumerable().Select(r => (Roles)Enum.Parse(typeof(Roles), r)).SingleOrDefault()
                }).Select(x => x.Result);

            return View(users);
        }
    }
}
