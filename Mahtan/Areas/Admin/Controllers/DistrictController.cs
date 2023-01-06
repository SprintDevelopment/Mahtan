using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.Assets;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class DistrictController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Districts.Find().AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(short id = 0)
        {
            if (id == 0)
                return View(new District());
            else
            {
                var entity = await _unitOfWork.Districts.GetAsync(id);
                if (entity != null)
                    return View(entity);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(District entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.DistrictId == 0)
                {
                    _unitOfWork.Districts.Add(entity);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    var oldEntity = await _unitOfWork.Districts.GetAsync(entity.DistrictId);
                    if (oldEntity != null)
                    {
                        _unitOfWork.Districts.Update(oldEntity, entity);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                        return NotFound();
                }
                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_DistrictListPartial", _unitOfWork.Districts.Find().AsEnumerable()) });
            }

            return Json(new { isValid = false, html = HtmlHelper.RenderRazorViewToString(this, "CreateOrUpdate", entity) });
        }

        public async Task<IActionResult> Delete(short id)
        {
            var entity = await _unitOfWork.Districts.GetAsync(id);

            if (entity != null)
            {
                _unitOfWork.Districts.Remove(entity);
                await _unitOfWork.CompleteAsync();

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_DistrictListPartial", _unitOfWork.Districts.Find().AsEnumerable()) });
            }
            else
                return Json(new { isValid = false, html = "آیتم مورد نظر پیدا نشد." });
        }
    }
}
