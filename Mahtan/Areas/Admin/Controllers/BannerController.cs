using Mahtan.Assets;
using Mahtan.Assets.Extensions;
using Mahtan.Assets.Values;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.Services;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class BannerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public BannerController(IFileService fileService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Banners.Find().AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(short id = 0)
        {
            if (id == 0)
                return View(new Banner());
            else
            {
                var entity = await _unitOfWork.Banners.GetAsync(id);
                if (entity != null)
                {
                    return View(entity);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(Banner banner)
        {
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
                banner.BannerGuid = await _fileService.UploadAsync(files[0], Addresses.BannerImagesPath, banner.BannerGuid);

            if (ModelState.IsValid && !banner.BannerGuid.IsNullOrWhitespace())
            {
                if (banner.BannerId == 0)
                {
                    _unitOfWork.Banners.Add(banner);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    var oldEntity = await _unitOfWork.Banners.GetAsync(banner.BannerId);
                    if (oldEntity != null)
                    {
                        _unitOfWork.Banners.Update(oldEntity, banner);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                        return NotFound();

                }
                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_BannerListPartial", _unitOfWork.Banners.Find().AsEnumerable()) });
            }

            return Json(new { isValid = false, html = HtmlHelper.RenderRazorViewToString(this, "CreateOrUpdate", banner) });
        }

        public async Task<IActionResult> Delete(short id)
        {
            var entity = await _unitOfWork.Banners.GetAsync(id);

            if (entity != null)
            {
                _unitOfWork.Banners.Remove(entity);
                await _unitOfWork.CompleteAsync();

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_BannerListPartial", _unitOfWork.Banners.Find().AsEnumerable()) });
            }
            else
                return Json(new { isValid = false, html = "آیتم مورد نظر پیدا نشد." });
        }
    }
}
