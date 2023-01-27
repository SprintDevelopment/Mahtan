using Mahtan.Data.Repositories;
using Mahtan.Models;
using Mahtan.Assets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class FaqController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FaqController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Faqs.Find().AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(short id = 0)
        {
            if (id == 0)
                return View(new Faq() { DisplayOrder = _unitOfWork.Faqs.Count() + 1 });
            else
            {
                var entity = await _unitOfWork.Faqs.GetAsync(id);
                if (entity != null)
                    return View(entity);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(Faq entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.FaqId == 0)
                {
                    _unitOfWork.Faqs.Add(entity);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    var oldEntity = await _unitOfWork.Faqs.GetAsync(entity.FaqId);
                    if (oldEntity != null)
                    {
                        _unitOfWork.Faqs.Update(oldEntity, entity);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                        return NotFound();
                }
                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_FaqListPartial", _unitOfWork.Faqs.Find().AsEnumerable()) });
            }

            return Json(new { isValid = false, html = HtmlHelper.RenderRazorViewToString(this, "CreateOrUpdate", entity) });
        }

        public async Task<IActionResult> Delete(short id)
        {
            var entity = await _unitOfWork.Faqs.GetAsync(id);

            if (entity != null)
            {
                _unitOfWork.Faqs.Remove(entity);
                await _unitOfWork.CompleteAsync();

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_FaqListPartial", _unitOfWork.Faqs.Find().AsEnumerable()) });
            }
            else
                return Json(new { isValid = false, html = "آیتم مورد نظر پیدا نشد." });
        }
    }
}
