using Storage.Api.Models;

namespace Storage.Api.Services
{
    public interface IProductsBatchesService
    {
        IEnumerable<ProductsBatch> GetProductsBatches();

        ProductsBatch? GetProductsBatch(Guid id);

        IEnumerable<ProductsBatch> GetProductsBatchesByState(State state);

        ProductsBatch CreateProductsBatch(ProductsBatch productsBatch);

        ProductsBatch? UpdateProductsBatch(Guid productsBatchId, ProductsBatch updatedProductsbatch);

        bool DeleteProductsBatch(Guid id);

    }
}