using Mahtan.Assets.Values.Enums;
using Mahtan.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mahtan.Areas.User.Controllers
{
    [Area(nameof(Areas.User))]
    [Authorize(Roles = nameof(Areas.User))]
    public class WishController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.WishItems.Find(wishItem => wishItem.Username == User.Identity.Name).Include(a => a.Product).AsEnumerable());
        }

        public async Task AddToWishList(int id)
        {
            var isAlreadyExists = await _unitOfWork.WishItems.Find(wishItem => wishItem.Username == User.Identity.Name && wishItem.ProductId == id).AnyAsync();
            if (!isAlreadyExists)
            {
                _unitOfWork.WishItems.Add(new Models.WishItem { Username = User.Identity.Name, ProductId = id });
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task RemoveFromWishList(int id)
        {
            var wishItem = await _unitOfWork.WishItems.Find(wishItem => wishItem.Username == User.Identity.Name && wishItem.ProductId == id).FirstOrDefaultAsync();
            if(wishItem != null)
            {
                _unitOfWork.WishItems.Remove(wishItem);
                await _unitOfWork.CompleteAsync();
            }
        }

    }
}
