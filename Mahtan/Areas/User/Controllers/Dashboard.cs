using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.User.Controllers
{
    [Area(nameof(Areas.User))]
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
