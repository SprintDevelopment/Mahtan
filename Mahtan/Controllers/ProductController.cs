using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
