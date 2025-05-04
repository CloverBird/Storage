using Microsoft.AspNetCore.Mvc;
using Storage.Core.Models;
using Storage.Core.Services;
using Storage.DataBase.Services;

namespace Storage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService, IProductsBatchesService productsBatchesService) {
            _reportsService = reportsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Report>> GetAllReports()
        {
            var reports = _reportsService.GetReports();
            return Ok(reports);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Report> GetReport(Guid id)
        {
            var report = _reportsService.GetReport(id);
            return report == null ? NotFound() : Ok(report);
        }

        [HttpGet("last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Report> GetLastReport()
        {
            var report = _reportsService.GetLastReport();
            return report == null ? NotFound() : Ok(report);
        }
    }
}