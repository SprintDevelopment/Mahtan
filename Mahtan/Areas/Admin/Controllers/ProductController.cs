using AutoMapper;
using Mahtan.Assets;
using Mahtan.Assets.Values;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.Services;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ProductController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Products.FindWithFirstImages().AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(int id = 0)
        {
            var viewModel = new ProductViewModel()
            {
                Product = new Product(),
                Categories = _unitOfWork.Categories.Find().AsEnumerable(),
                Brands = _unitOfWork.Brands.Find().AsEnumerable()
            };

            if (id == 0)
                return View(viewModel);
            else
            {
                var entity = await _unitOfWork.Products.GetAsync(id);
                if (entity != null)
                {
                    viewModel.Product = entity;
                    return View(viewModel);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                    _unitOfWork.Products.Add(product, true);
                else
                {
                    var oldEntity = await _unitOfWork.Products.GetAsync(product.ProductId);
                    if (oldEntity != null)
                    {
                        _unitOfWork.Products.Update(oldEntity, product);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                        return NotFound();
                }

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    _unitOfWork.ProductImages
                        .Find(pi => pi.ProductId == product.ProductId)
                        .ToList()
                        .ForEach(pi =>
                        {
                            _fileService.Delete(Addresses.ProductLargeImagesPath, pi.ImageGuid);
                            _fileService.Delete(Addresses.ProductThumbImagesPath, pi.ImageGuid);
                            _unitOfWork.ProductImages.Remove(pi);
                        });

                    _unitOfWork.ProductImages
                        .AddRange(
                         files.Select(async file => await _fileService.UploadAsync(file, Addresses.ProductLargeImagesPath))
                         .Select(fileGuid => new ProductImage
                         {
                             ProductId = product.ProductId,
                             ImageGuid = fileGuid.Result,
                             OptionalComment = ""
                         }));

                    await _unitOfWork.CompleteAsync();
                }

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_ProductListPartial", _unitOfWork.Products.FindWithFirstImages().AsEnumerable()) });
            }

            var viewModel = new ProductViewModel()
            {
                Product = product,
                Categories = _unitOfWork.Categories.Find().AsEnumerable(),
                Brands = _unitOfWork.Brands.Find().AsEnumerable()
            };

            return Json(new { isValid = false, html = HtmlHelper.RenderRazorViewToString(this, "CreateOrUpdate", viewModel) });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Products.GetAsync(id);

            if (entity != null)
            {
                _unitOfWork.ProductImages
                    .Find(pi => pi.ProductId == id)
                    .ToList()
                    .ForEach(pi =>
                    {
                        _fileService.Delete(Addresses.ProductLargeImagesPath, pi.ImageGuid);
                        _fileService.Delete(Addresses.ProductThumbImagesPath, pi.ImageGuid);
                        _unitOfWork.ProductImages.Remove(pi);
                    });

                _unitOfWork.Products.Remove(entity);
                await _unitOfWork.CompleteAsync();

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_ProductListPartial", _unitOfWork.Products.FindWithFirstImages().AsEnumerable()) });
            }
            else
                return Json(new { isValid = false, html = "آیتم مورد نظر پیدا نشد." });
        }
    }
}
