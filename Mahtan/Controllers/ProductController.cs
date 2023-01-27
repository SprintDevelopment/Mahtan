using Mahtan.Data.Repositories;
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

        public IActionResult Index()
        {
            var viewModel = new ProductListViewModel()
            {
                Products = _unitOfWork.Products.FindWithFirstImages().AsEnumerable(),
                SearchViewModel = new ProductSearchViewModel() 
                {
                    Categories = _unitOfWork.Categories.Find().AsEnumerable().GroupBy(c => c.ParentCategoryId).SelectMany(g => g),
                    Brands = _unitOfWork.Brands.Find().Select(b => new SelectableBrand(b)).AsEnumerable()
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
                .Include(p => p.Category)
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
    }
}
