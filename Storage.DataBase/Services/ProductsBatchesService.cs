using Microsoft.EntityFrameworkCore;
using Storage.Core.Models;
using Storage.Core.Services;
using Storage.DataBase.DbContexts;

namespace Storage.DataBase.Services
{
    public class ProductsBatchesService : IProductsBatchesService
    {
        private readonly AppDbContext _dbContext;
        protected DbSet<ProductsBatch> ProductsBatches => _dbContext.Set<ProductsBatch>();

        public ProductsBatchesService(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public ProductsBatch CreateProductsBatch(ProductsBatch productsBatch)
        {
            var created = productsBatch.CloneWithNewId();

            ProductsBatches.Add(created);
            _dbContext.SaveChanges();

            return created.Clone();
        }

        public IEnumerable<ProductsBatch> GetProductsBatches()
        {
            return ProductsBatches.AsNoTracking();
        }

        public ProductsBatch? GetProductsBatch(Guid id)
        {
            var productsBatch = ProductsBatches.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (productsBatch == null)
                return null;
            
            return productsBatch;
        }

        public IEnumerable<ProductsBatch> GetProductsBatchesByState(State state)
        {
            return ProductsBatches.AsNoTracking().Where(p => p.State == state);
        }

        public ProductsBatch? UpdateProductsBatch(Guid productsBatchId, ProductsBatch updatedProductsBatch)
        {
            var productsBatch = ProductsBatches.FirstOrDefault(p => p.Id == productsBatchId);
            if (productsBatch == null)
                return null;

            productsBatch.ProductName = updatedProductsBatch.ProductName;
            productsBatch.ProductDescription = updatedProductsBatch.ProductDescription;
            productsBatch.ProducingDate = updatedProductsBatch.ProducingDate;
            productsBatch.ExpirationDate = updatedProductsBatch.ExpirationDate;
            productsBatch.Discount = updatedProductsBatch.Discount;
            productsBatch.ProductPrice = updatedProductsBatch.ProductPrice;
            productsBatch.Quantity = updatedProductsBatch.Quantity;

            _dbContext.SaveChanges();

            return productsBatch.Clone();
        }

        public bool DeleteProductsBatch(Guid id)
        {
            var productBatch = ProductsBatches.FirstOrDefault(p => p.Id == id);
            if (productBatch == null) return false;

            ProductsBatches.Remove(productBatch);
            _dbContext.SaveChanges();
            return true;
        }
    }
}