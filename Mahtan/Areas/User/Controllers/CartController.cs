using Mahtan.Models;
using Mahtan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area(nameof(User))]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();

            return View(cartItems);
        }

        [HttpGet]
        public IActionResult Items()
        {
            return Json(_cartService.GetCartItems());
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var addResult = await _cartService.AddToCartAsync(id);
            return addResult.Qty > 0 ? Ok(addResult) : NotFound();
        }

        public async Task<IActionResult> UpdateCartItem(int id, int incOrDecQty)
        {
            var updateResult = await _cartService.UpdateCartItemAsync(id, incOrDecQty);
            return updateResult.Qty > 0 ? Ok(updateResult) : NotFound();
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            return Ok(await _cartService.RemoveFromCartAsync(id));
        }
    }
}
