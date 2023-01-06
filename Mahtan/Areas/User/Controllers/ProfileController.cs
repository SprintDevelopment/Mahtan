using Mahtan.Assets;
using Mahtan.Assets.Dtos;
using Mahtan.Assets.Values;
using Mahtan.Assets.Values.Enums;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.User.Controllers
{
    [Area(nameof(Areas.User))]
    [Authorize(Roles = nameof(Areas.User))]
    public class ProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ProfileController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Profiles.Find(p => p.Username == User.Identity.Name).FirstOrDefault() ?? new Profile());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Profile entity)
        {
            entity.Username = User.Identity.Name;
            ModelState.Remove("Username");

            var oldEntity = await _unitOfWork.Profiles.GetAsync(User.Identity.Name);
            
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
                entity.OptionalAvatarGuid = await _fileService.UploadAsync(files[0], Addresses.UserAvatarImagesPath, oldEntity?.OptionalAvatarGuid);
            else
                entity.OptionalAvatarGuid = oldEntity?.OptionalAvatarGuid;

            if (ModelState.IsValid)
            {
                if (oldEntity != null)
                    _unitOfWork.Profiles.Update(oldEntity, entity);
                else
                    _unitOfWork.Profiles.Add(entity);

                await _unitOfWork.CompleteAsync();

                return Json(new
                {
                    isValid = true,
                    html = HtmlHelper.RenderRazorViewToString(this, "_AlertPartial", new AlertDto { AlertType = AlertTypes.Success, Message = "پروفایل با موفقیت ذخیره شد." }),
                    userFullName = entity.FullName,
                    userAvatar = entity.OptionalAvatarGuid
                });
            }

            return Json(new
            {
                isValid = false,
                html = HtmlHelper.RenderRazorViewToString(this, "_AlertPartial", new AlertDto { AlertType = AlertTypes.Error, Message = "خطایی در ذخیره پروفایل وجود دارد." })
            });
        }
    }
}
