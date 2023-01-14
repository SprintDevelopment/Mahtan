using Mahtan.Assets;
using Mahtan.Assets.Extensions;
using Mahtan.Assets.Values;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.Services;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public BrandController(IFileService fileService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Brands.Find().AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(short id = 0)
        {
            if (id == 0)
                return View(new Brand());
            else
            {
                var entity = await _unitOfWork.Brands.GetAsync(id);
                if (entity != null)
                {
                    return View(entity);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(Brand brand)
        {
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
                brand.LogoGuid = await _fileService.UploadAsync(files[0], Addresses.BrandLogosPath, brand.LogoGuid);

            if (ModelState.IsValid)
            {
                if (brand.BrandId == 0)
                {
                    _unitOfWork.Brands.Add(brand);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    var oldEntity = await _unitOfWork.Brands.GetAsync(brand.BrandId);
                    if (oldEntity != null)
                    {
                        _unitOfWork.Brands.Update(oldEntity, brand);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                        return NotFound();

                }
                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_BrandListPartial", _unitOfWork.Brands.Find().AsEnumerable()) });
            }

            return Json(new { isValid = false, html = HtmlHelper.RenderRazorViewToString(this, "CreateOrUpdate", brand) });
        }

        public async Task<IActionResult> Delete(short id)
        {
            var entity = await _unitOfWork.Brands.GetAsync(id);

            if (entity != null)
            {
                _unitOfWork.Brands.Remove(entity);
                await _unitOfWork.CompleteAsync();

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_BrandListPartial", _unitOfWork.Brands.Find().AsEnumerable()) });
            }
            else
                return Json(new { isValid = false, html = "آیتم مورد نظر پیدا نشد." });
        }
    }
}
