using Storage.Core.Models;
using Storage.Core.Services;

namespace Storage.Api.Services
{
    public class ProductsBatchesService : IProductsBatchesService
    {
        private readonly List<ProductsBatch> _productsBatches = new List<ProductsBatch>();

        public ProductsBatch CreateProductsBatch(ProductsBatch productBatch)
        {
            var newProductBatch = productBatch.CloneWithNewId();

            _productsBatches.Add(newProductBatch);

            return newProductBatch;
        }

        public bool DeleteProductsBatch(Guid id)
        {
            var productsBatch = _productsBatches.FirstOrDefault(p => p.Id == id);
            return productsBatch != null && _productsBatches.Remove(productsBatch);
        }

        public ProductsBatch? GetProductsBatch(Guid id) => _productsBatches.FirstOrDefault(p => p.Id == id);

        public IEnumerable<ProductsBatch> GetProductsBatches() => _productsBatches;

        public IEnumerable<ProductsBatch> GetProductsBatchesByState(State state)
         {
            var productsBatches = GetProductsBatches();

            return productsBatches.Where(p => p.State == state);
        }

        public ProductsBatch? UpdateProductsBatch(Guid productsBatchId, ProductsBatch updatedProductsBatch)
        {
            var productsBatch = _productsBatches.FirstOrDefault(p => p.Id == productsBatchId);
            if (productsBatch == null) return null;

            productsBatch.ProductName = updatedProductsBatch.ProductName;
            productsBatch.ProductDescription = updatedProductsBatch.ProductDescription;
            productsBatch.ProducingDate = updatedProductsBatch.ProducingDate;
            productsBatch.ExpirationDate = updatedProductsBatch.ExpirationDate;
            productsBatch.Discount = updatedProductsBatch.Discount;
            productsBatch.ProductPrice = updatedProductsBatch.ProductPrice;
            productsBatch.Quantity = updatedProductsBatch.Quantity;

            return productsBatch;
        }
    }
}