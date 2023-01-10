using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.Services;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mahtan.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var viewModel = new MainPageViewModel
            {
                Banners = _unitOfWork.Banners.Find(b => b.IsActive).AsEnumerable()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}