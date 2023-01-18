using Mahtan.Assets;
using Mahtan.Assets.Values.Enums;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mahtan.Areas.User.Controllers
{
    [Area(nameof(Areas.User))]
    [Authorize(Roles = nameof(Areas.User))]
    public class ProductReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(long id = 0)
        {
            if (id == 0)
                return View(new ProductReview());
            else
            {
                var entity = await _unitOfWork.ProductReviews.GetAsync(id);
                if (entity != null)
                    return View(entity);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(ProductReview review)
        {
            review.WriterUsername = User.Identity.Name;
            ModelState.Remove("WriterUsername");

            if (ModelState.IsValid)
            {
                if (review.ProductReviewId == 0)
                {
                    _unitOfWork.ProductReviews.Add(review);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    var oldEntity = await _unitOfWork.ProductReviews.GetAsync(review.ProductReviewId);
                    if (oldEntity != null)
                    {
                        _unitOfWork.ProductReviews.Update(oldEntity, review);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                        return NotFound();

                }
                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_AddressListPartial", _unitOfWork.Addresses.Find(address => address.Username == User.Identity.Name).Include(a => a.District).AsEnumerable()) });
            }

            return Json(new { isValid = false, html = HtmlHelper.RenderRazorViewToString(this, "CreateOrUpdate", review) });
        }
    }
}
