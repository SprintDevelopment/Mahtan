using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.Assets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class ShippingTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShippingTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.ShippingTypes.Find().AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(short id = 0)
        {
            if (id == 0)
                return View(new ShippingType() { DisplayOrder = _unitOfWork.ShippingTypes.Count() + 1 });
            else
            {
                var entity = await _unitOfWork.ShippingTypes.GetAsync(id);
                if (entity != null)
                    return View(entity);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(ShippingType entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.ShippingTypeId == 0)
                {
                    _unitOfWork.ShippingTypes.Add(entity);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    var oldEntity = await _unitOfWork.ShippingTypes.GetAsync(entity.ShippingTypeId);
                    if (oldEntity != null)
                    {
                        _unitOfWork.ShippingTypes.Update(oldEntity, entity);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                        return NotFound();
                }
                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_ShippingTypeListPartial", _unitOfWork.ShippingTypes.Find().AsEnumerable()) });
            }

            return Json(new { isValid = false, html = HtmlHelper.RenderRazorViewToString(this, "CreateOrUpdate", entity) });
        }

        public async Task<IActionResult> Delete(short id)
        {
            var entity = await _unitOfWork.ShippingTypes.GetAsync(id);

            if (entity != null)
            {
                _unitOfWork.ShippingTypes.Remove(entity);
                await _unitOfWork.CompleteAsync();

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_ShippingTypeListPartial", _unitOfWork.ShippingTypes.Find().AsEnumerable()) });
            }
            else
                return Json(new { isValid = false, html = "آیتم مورد نظر پیدا نشد." });
        }
    }
}
