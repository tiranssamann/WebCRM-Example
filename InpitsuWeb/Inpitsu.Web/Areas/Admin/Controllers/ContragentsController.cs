using Microsoft.AspNetCore.Mvc;
using Inpitsu.Servises.Interfaces;
using Inpitsu.Logger;
using Inpitsu.Filters;
using Inpitsu.Data.DtoObjects;
namespace Inpitsu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContragentsController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _service;
        public ContragentsController(ILoggerManager logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;

        }
        [HttpGet]
        public IActionResult Index(PaginationFilter paginationFilter)
        {
            try
            {
                var contragentes = _service.ContragentService.GetAll(trackChanges: false, paginationFilter);
                var contragentesCount = _service.ContragentService.GetContragentCount(trackChanges: false);
                ViewData["contragentCount"] = contragentesCount;
                ViewData["PaginationPageSize"] = paginationFilter.PageSize;
                ViewData["PaginationPageNumber"] = paginationFilter.PageNumber;
                return View("Index", contragentes);
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
        public RedirectToActionResult Submit([FromForm] ContragentCreateDto contragentCreateDto)
        {
            try
            {
                _service.ContragentService.CreateContragent(contragentCreateDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }
        public IActionResult AddContragent()
        {
            return View("AddContragent");
        }
        public RedirectToActionResult Deletecontragent(Guid id)
        {
            try
            {
                _service.ContragentService.DeleteContragent(id, trackChanges: false);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editcontragent(Guid id)
        {
            try
            {
                var contragent = _service.ContragentService.GetContragent(id, trackChanges: false);
                if (contragent == null)
                {
                    return BadRequest();
                }
                
                return View(contragent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
