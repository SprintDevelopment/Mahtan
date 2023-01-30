using Mahtan.Data.Repositories;
using Mahtan.Services;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public OrderController(IFileService fileService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Orders.Find().Include(o => o.UserProfile).Include(o => o.Items).AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _unitOfWork.Orders.GetAsync(id);
            if (order != null)
            {
                return View(new OrderDetailsViewModel() 
                {
                    Order = order,
                    Items = _unitOfWork.OrderItems.Find(oi => oi.OrderId == id)
                                .Include(oi => oi.Product).ThenInclude(p => p.Category)
                                .Include(oi => oi.Product).ThenInclude(p => p.Images.Take(1))
                                .AsEnumerable()
                });
            }

            return NotFound();
        }
    }
}
