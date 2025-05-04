using Microsoft.EntityFrameworkCore;
using Storage.DataBase.EntityTypeConfigurations;

namespace Storage.DataBase.DbContexts
{
    public class ProductsBatchesDbContext : DbContext
    {
        public ProductsBatchesDbContext(DbContextOptions<ProductsBatchesDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductsBatchConfiguration());
        }
    }
}