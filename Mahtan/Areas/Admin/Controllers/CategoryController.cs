using Mahtan.Assets;
using Mahtan.Assets.Values;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.Services;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CategoryController(IFileService fileService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Categories.Find().AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(short id = 0)
        {
            var viewModel = new CategoryViewModel()
            {
                Category = new Category(),
                ParentCategories = _unitOfWork.Categories.FindAllExceptItselfAndChildren(id),
            };

            if (id == 0)
                return View(viewModel);
            else
            {
                var entity = await _unitOfWork.Categories.GetAsync(id);
                if (entity != null)
                {
                    viewModel.Category = entity;
                    return View(viewModel);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(Category category)
        {
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
                category.IconGuid = await _fileService.UploadAsync(files[0], Addresses.CategoryIconsPath, category.IconGuid);

            if (ModelState.IsValid)
            {
                if (category.CategoryId == 0)
                {
                    _unitOfWork.Categories.Add(category);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    var oldEntity = await _unitOfWork.Categories.GetAsync(category.CategoryId);
                    if (oldEntity != null)
                    {
                        _unitOfWork.Categories.Update(oldEntity, category);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                        return NotFound();

                }
                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_CategoryListPartial", _unitOfWork.Categories.Find().AsEnumerable()) });
            }

            var viewModel = new CategoryViewModel()
            {
                Category = category,
                ParentCategories = _unitOfWork.Categories.FindAllExceptItselfAndChildren(category.CategoryId),
            };

            return Json(new { isValid = false, html = HtmlHelper.RenderRazorViewToString(this, "CreateOrUpdate", viewModel) });
        }

        public async Task<IActionResult> Delete(short id)
        {
            var entity = await _unitOfWork.Categories.GetAsync(id);

            if (entity != null)
            {
                _unitOfWork.Categories.Remove(entity);
                await _unitOfWork.CompleteAsync();

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_CategoryListPartial", _unitOfWork.Categories.Find().AsEnumerable()) });
            }
            else
                return Json(new { isValid = false, html = "آیتم مورد نظر پیدا نشد." });
        }
    }
}
