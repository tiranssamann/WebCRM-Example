using Microsoft.AspNetCore.Mvc;
using Inpitsu.Servises.Interfaces;
using Inpitsu.Logger;
using Inpitsu.Filters;
using Inpitsu.Data.DtoObjects;
namespace Inpitsu.Web.Areas.Admins.Controllers
{
    [Area("Admin")]
    public class ProcessesController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _service;
        public ProcessesController(ILoggerManager logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;

        }
        [HttpGet]
        public IActionResult Index(PaginationFilter paginationFilter)
        {
            try
            {
                var processes = _service.ProcessService.GetAll(trackChanges: false, paginationFilter);
                var processesCount = _service.ProcessService.GetProcessCount(trackChanges: false);
                ViewData["ProcessCount"] = processesCount;
                ViewData["PaginationPageSize"] = paginationFilter.PageSize;
                ViewData["PaginationPageNumber"] = paginationFilter.PageNumber;
                return View("Index",processes);   
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
        public RedirectToActionResult Cansel()
        {
            return RedirectToAction("Index");
        }
        public RedirectToActionResult Submit([FromForm] ProcessCreateDto processCreateDto)
        {
            try
            {
                _service.ProcessService.CreateProcess(processCreateDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }
        public IActionResult AddForm()
        {
            return View("AddForm");
        }
        public RedirectToActionResult DeleteProcess(Guid id)
        {
            try
            {
                _service.ProcessService.DeleteProcess(id, trackChanges: false);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }
        public IActionResult EditProcess(Guid id)
        {
            try
            {
                var formSettings = _service.ProcessService.GetProcess(id, trackChanges: false);
                if (formSettings == null)
                {
                    return BadRequest();
                }
                return View(formSettings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
