using Mahtan.Assets.Values.Enums;
using Mahtan.Data.Repositories;
using Mahtan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mahtan.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class ContentTemplateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ContentTemplateController(IFileService fileService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.ContentTemplates.Find().AsEnumerable());
        }
    }
}
