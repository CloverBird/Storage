using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Storage.Core.Models;
using Storage.Core.Services;

namespace Storage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsBatchesController : ControllerBase
    {
        private readonly IProductsBatchesService _productsBatchesService;

        private readonly IValidator<ProductsBatch> _productsBatchesValidator;

        public ProductsBatchesController(IProductsBatchesService productsBatchesService, IValidator<ProductsBatch> productsBatchesValidator) {
            _productsBatchesService = productsBatchesService;
            _productsBatchesValidator = productsBatchesValidator;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductsBatch> CreateProductsBatch([FromBody] ProductsBatch productsBatch)
        {
            var validationResult = _productsBatchesValidator.Validate(productsBatch);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            var createdProductsBatch = _productsBatchesService.CreateProductsBatch(productsBatch);

            return CreatedAtAction(nameof(GetProductsBatchById), new { id = createdProductsBatch.Id }, createdProductsBatch);
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductsBatch>> GetAllProductsBatches()
        {
            var productsBatches = _productsBatchesService.GetProductsBatches();

            return Ok(productsBatches);
        }

        [HttpGet("{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductsBatch> GetProductsBatchById(Guid id)
        {
            var productsBatch = _productsBatchesService.GetProductsBatch(id);

            return productsBatch == null ? NotFound() : Ok(productsBatch);
        }

        [HttpPut("{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductsBatch> UpdateGood(Guid id, [FromBody] ProductsBatch updatedProductsBatch)
        {
            var validationResult = _productsBatchesValidator.Validate(updatedProductsBatch);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            var productsBatch = _productsBatchesService.UpdateProductsBatch(id, updatedProductsBatch);

            return productsBatch == null ? NotFound() : Ok(productsBatch);
        }

        [HttpPatch("{id:guid}/reduce")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductsBatch> ReduceQuantity(Guid id, [FromBody] int amount)
        {
            if (amount <= 0)
                return BadRequest("Amount must be greater than 0.");

            var productsBatch = _productsBatchesService.GetProductsBatch(id);
            if (productsBatch == null)
                return NotFound();

            if (productsBatch.Quantity < amount)
                return BadRequest("Not enough quantity in stock.");

            productsBatch.Quantity -= amount;
            _productsBatchesService.UpdateProductsBatch(id, productsBatch);

            return Ok(productsBatch);
        }

        [HttpDelete("{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteProductsBatch(Guid id)
        {
            return _productsBatchesService.DeleteProductsBatch(id) ?
                NoContent() : NotFound();
        }
    }
}