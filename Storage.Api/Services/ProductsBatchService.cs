using Storage.Api.Models;

namespace Storage.Api.Services
{
    public class ProductsBatchesService : IProductsBatchesService
    {
        private readonly List<ProductsBatch> _productsBatches = new List<ProductsBatch>();

        public ProductsBatch CreateProductsBatch(ProductsBatch productBatch)
        {
            var newProductBatch = new ProductsBatch {
                Id = Guid.NewGuid(),
                ProductName = productBatch.ProductName,
                ProductDescription = productBatch.ProductDescription,
                ProducingDate = productBatch.ProducingDate,
                ExpirationDate = productBatch.ExpirationDate,
                Discount = productBatch.Discount,
                ProductPrice = productBatch.ProductPrice,
                Quantity = productBatch.Quantity
            };

            _productsBatches.Add(newProductBatch);

            return newProductBatch;
        }

        public bool DeleteProductsBatch(Guid id)
        {
            var productsBatch = _productsBatches.FirstOrDefault(p => p.Id == id);
            if (productsBatch == null)
                return false;

            _productsBatches.Remove(productsBatch);
            return true;
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