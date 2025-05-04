using Storage.Core.Models;

namespace Storage.Core.Services
{
    public interface IProductsBatchesService
    {
        IEnumerable<ProductsBatch> GetProductsBatches();

        ProductsBatch? GetProductsBatch(Guid id);

        IEnumerable<ProductsBatch> GetProductsBatchesByState(State state);

        ProductsBatch CreateProductsBatch(ProductsBatch productsBatch);

        ProductsBatch? UpdateProductsBatch(Guid productsBatchId, ProductsBatch updatedProductsBatch);

        bool DeleteProductsBatch(Guid id);

    }
}