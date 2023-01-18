using Mahtan.Assets;
using Mahtan.Assets.Values;
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
    public class AddressController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Addresses.Find(address => address.Username == User.Identity.Name).Include(a => a.District).AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(int id = 0)
        {
            var viewModel = new AddressViewModel()
            {
                Address = new Address(),
                Districts = _unitOfWork.Districts.Find().AsEnumerable(),
            };

            if (id == 0)
                return View(viewModel);
            else
            {
                var entity = await _unitOfWork.Addresses.GetAsync(id);
                if (entity != null)
                {
                    viewModel.Address = entity;
                    return View(viewModel);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(Address address)
        {
            address.Username = User.Identity.Name;
            ModelState.Remove("Address.Username");

            if (ModelState.IsValid)
            {
                if (address.AddressId == 0)
                {
                    _unitOfWork.Addresses.Add(address);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    var oldEntity = await _unitOfWork.Addresses.GetAsync(address.AddressId);
                    if (oldEntity != null)
                    {
                        _unitOfWork.Addresses.Update(oldEntity, address);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                        return NotFound();

                }
                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_AddressListPartial", _unitOfWork.Addresses.Find(address => address.Username == User.Identity.Name).Include(a => a.District).AsEnumerable()) });
            }

            var viewModel = new AddressViewModel()
            {
                Address = address,
                Districts = _unitOfWork.Districts.Find().AsEnumerable(),
            };

            return Json(new { isValid = false, html = HtmlHelper.RenderRazorViewToString(this, "CreateOrUpdate", viewModel) });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Addresses.GetAsync(id);

            if (entity != null)
            {
                _unitOfWork.Addresses.Remove(entity);
                await _unitOfWork.CompleteAsync();

                return Json(new { isValid = true, html = HtmlHelper.RenderRazorViewToString(this, "_AddressListPartial", _unitOfWork.Addresses.Find(address => address.Username == User.Identity.Name).Include(a => a.District).AsEnumerable()) });
            }
            else
                return Json(new { isValid = false, html = "آیتم مورد نظر پیدا نشد." });
        }
    }
}
