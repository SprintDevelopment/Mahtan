using Mahtan.Assets;
using Mahtan.Assets.Values;
using Mahtan.Assets.Values.Enums;
using Mahtan.Data.Repositories;
using Mahtan.Services;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class ProductSizeItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ProductSizeItemController(IFileService fileService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult SizeItems(short id)
        {
            return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_ProductSizeItemListPartial", new SizeItemsWrapperViewModel { Product = new FakeNamespace.Product { CategorySizeItems = _unitOfWork.ProductSizeItems.Find(si => si.ProductSizeId == id).ToArray() } }) });
        }
    }
}
