using Mahtan.Models;
using Mahtan.Data.Repositories;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Mahtan.Assets.Extensions;

namespace Mahtan.Services
{
    public interface ICartService
    {
        Task<CartItem> AddToCartAsync(int productId);
        Task<CartItem> UpdateCartItemAsync(int productId, int incOrDecQty);
        Task<CartItem> RemoveFromCartAsync(int productId);
        List<CartItem> GetCartItems();
    }

    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private ClaimsPrincipal _user => _httpContextAccessor.HttpContext.User;
        private bool _isUserAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public CartService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CartItem> AddToCartAsync(int productId)
        {
            return await UpdateCartItemAsync(productId, 1);
        }

        public async Task<CartItem> UpdateCartItemAsync(int productId, int incOrDecQty)
        {
            var product = await _unitOfWork.Products.FindWithFirstImages(p => p.ProductId == productId).FirstOrDefaultAsync();
            if (product is null)
                return null;

            CartItem cartItem = null;

            if (_isUserAuthenticated)
            {
                cartItem = _unitOfWork.CartItems.Find(ci => ci.Username == _user.Identity.Name).FirstOrDefault() ?? new CartItem { ProductId = productId, Product = product, Price = product.Price };
                cartItem.Qty += incOrDecQty;

                if (cartItem.Qty > 0 && cartItem.CartItemId == 0)
                    _unitOfWork.CartItems.Add(cartItem);
                else if(cartItem.Qty <= 0 && cartItem.CartItemId != 0)
                    _unitOfWork.CartItems.Remove(cartItem);
                
                await _unitOfWork.CompleteAsync();
            }
            else
            {
                var cartItems = _session.GetObjectFromJson<List<CartItem>>("CartItems") ?? new List<CartItem>();
                cartItem = cartItems.Find(ci => ci.Username == _user.Identity.Name) ?? new CartItem { ProductId = productId, Product = product, Price = product.Price };
                cartItem.Qty += incOrDecQty;

                if (cartItem.Qty > 0 && cartItem.CartItemId == 0)
                    cartItems.Add(cartItem);
                else if (cartItem.Qty <= 0)
                    cartItems.Remove(cartItem);

                _session.SetObjectAsJson("CartItems", cartItems);
            }

            return cartItem;
        }

        public async Task<CartItem> RemoveFromCartAsync(int productId)
        {
            return await UpdateCartItemAsync(productId, int.MinValue);
        }

        public List<CartItem> GetCartItems()
        {
            if (_isUserAuthenticated)
                return _unitOfWork.CartItems.Find(ci => ci.Username == _user.Identity.Name).ToList();
            else
                return _session.GetObjectFromJson<List<CartItem>>("CartItems") ?? new List<CartItem>();
        }
    }
}
