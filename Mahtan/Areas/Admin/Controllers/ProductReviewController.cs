﻿using Mahtan.Assets.Values.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class ProductReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
