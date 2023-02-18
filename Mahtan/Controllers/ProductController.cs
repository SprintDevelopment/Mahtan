using Mahtan.Assets;
using Mahtan.Assets.Extensions;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mahtan.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(ProductSearchViewModel searchViewModel)
        {
            var query = _unitOfWork.Products.FindWithFirstImages();
            if(searchViewModel.SelectedCategoryId > 0)
                query = query.Where(p => p.CategoryId == searchViewModel.SelectedCategoryId);
            
            var selectedBrands = searchViewModel.Brands?.Where(b => b.IsSelected).Select(b => b.BrandId);
            if(!selectedBrands.IsNullOrEmpty())
                query = query.Where(p => p.BrandId.HasValue && selectedBrands.Contains(p.BrandId.Value));

            if (searchViewModel.MaximumPrice > 0)
                query = query.Where(p => p.Price - (p.Price * p.DiscountPercent) >= searchViewModel.MinimumPrice && p.Price - (p.Price * p.DiscountPercent) <= searchViewModel.MaximumPrice);
            
            var viewModel = new ProductListViewModel()
            {
                Products = query.ToList(),
                SearchViewModel = new ProductSearchViewModel()
                {
                    Categories = _unitOfWork.Categories.Find().AsEnumerable().Prepend(new Category { CategoryId = 0, Title = "همه دسته ها" }),
                    Brands = _unitOfWork.Brands.Find().ToArray()
                }
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _unitOfWork.Products.Find(p => p.ProductId == id)
                .Include(p => p.Images)
                .Include(p => p.Reviews.Where(pr => pr.CheckStates == Assets.Values.Enums.ReviewCheckStates.Accepted)).ThenInclude(pr => pr.WriterProfile)
                .Include(p => p.Category).ThenInclude(c => c.ProductSize).ThenInclude(ps => ps.SizeItems)
                .Include(p => p.Brand).SingleOrDefault();

            if (product != null)
            {
                return View(
                    new ProductDetailsViewModel
                    {
                        Product = product,
                        ShippingTypes = _unitOfWork.ShippingTypes.Find().AsEnumerable(),
                        RelatedProducts = _unitOfWork.Products.FindWithFirstImages().AsEnumerable(),
                        SimilarProducts = _unitOfWork.Products.FindWithFirstImages().AsEnumerable(),
                    });
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult QuickView(int id)
        {
            var product = _unitOfWork.Products.Find(p => p.ProductId == id)
                .Include(p => p.Images)
                .Include(p => p.Category).ThenInclude(c => c.ProductSize).ThenInclude(ps => ps.SizeItems)
                .Include(p => p.Brand).SingleOrDefault();

            if (product != null)
            {
                var viewModel = new ProductDetailsViewModel
                {
                    Product = product,
                    ShippingTypes = _unitOfWork.ShippingTypes.Find().AsEnumerable(),
                };

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_ProductQuickViewPartial", viewModel) });
            }

            return Json(new { isValid = false });
        }
    }
}
