using Mahtan.Data.Repositories;
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
            return View();
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
                return View(product);

            return NotFound();
        }
    }
}
