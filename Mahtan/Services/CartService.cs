using Mahtan.Models;
using Microsoft.AspNetCore.Identity;
using Mahtan.Assets.Extensions;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Mahtan.Services
{
    public interface ICartService
    {
        Task<CartItem> AddToCartAsync(int productId);
        Task<CartItem> UpdateCartItemAsync(int productId, int incOrDecQty);
        Task RemoveFromCartAsync(int productId);
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
            //var product = await _unitOfWork.Products.FindWithFirstImages(p => p.ProductId == productId).FirstOrDefaultAsync();

            //if (product != null)
            //{
            //    var cartItems = GetCartItems();
            //    var cartItem = cartItems.SingleOrDefault(ci => ci.ProductId == productId);
            //    if (cartItem == null)
            //    {
            //        cartItem = new CartItem { ProductId = productId, Product = product, Price = product.Price, Qty = 1 };

            //        if (_user.Identity.IsAuthenticated)
            //        {
            //            cartItem.Username = _user.Identity.Name;
            //            _unitOfWork.CartItems.Add(cartItem);
            //            await _unitOfWork.CompleteAsync();
            //        }
            //        else
            //        {
            //            cartItems.Add(cartItem);
            //            _session.SetObjectAsJson("CartItems", cartItems);
            //        }

            //        return cartItem;
            //    }

            //    return await UpdateCartItemAsync(productId, true);
            //}

            //return null;

            return await UpdateCartItemAsync(productId, 1);
        }

        public Task<CartItem> UpdateCartItemAsync(int productId, int incOrDecQty)
        {
            var product = await _unitOfWork.Products.GetWithIncludeAsync(p => p.ProductId == productId);
            if (product is null)
                return null;

            var cartItem = GetCartItems().FirstOrDefault(ci => ci.ProductId == productId) ?? new CartItem { ProductId = productId, Product = product, Price = product.Price };
                cartItem.Qty += isIncrease;

                    if (_isUserAuthenticated)
                    {
                        if (cartItem.Qty <= 0 && cartItem.CII)
                        {
                            cartItem = null;
                        }
                        _unitOfWork.CartItems.Update(cartItem, cartItem);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                    {
                        _session.SetObjectAsJson("CartItems", cartItems);
                    }

            return cartItem;
        }

        public async Task RemoveFromCartAsync(int productId)
        {
            await UpdateCartItemAsync(productId, int.MinValue);
        }

        public List<CartItem> GetCartItems()
        {
            if (_user.Identity.IsAuthenticated)
                return _unitOfWork.CartItems.Find(ci => ci.Username == _user.Identity.Name).ToList();
            else
                return _session.GetObjectFromJson<List<CartItem>>("CartItems") ?? new List<CartItem>();
        }
    }
}
