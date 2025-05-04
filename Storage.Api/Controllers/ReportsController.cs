using Microsoft.AspNetCore.Mvc;
using Storage.Core.Models;
using Storage.Core.Services;

namespace Storage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IProductsBatchesService _productsBatchesService;

        public ReportsController(IProductsBatchesService productsBatchesService) {
            _productsBatchesService = productsBatchesService;
        }

        [HttpGet("state/{state}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductsBatch>> GetBatchesByState(State state)
        {
            var productsBatches = _productsBatchesService.GetProductsBatches();
            var productsBatchesByState = productsBatches.Where(p => p.State == state);
            return Ok(productsBatchesByState);
        }

        // [HttpGet("stats")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public ActionResult<Report> GetStats()
        // {
        //     var batches = _productsBatchesService.GetProductsBatches();

        //     var stats = new Report
        //     {
        //         Fresh = batches.Count(p => p.State == State.Fresh),
        //         SoonSpoiled = batches.Count(p => p.State == State.SoonSpoiled),
        //         Spoiled = batches.Count(p => p.State == State.Spoiled)
        //     };

        //     return Ok(stats);
        // }
    }
}