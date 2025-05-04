using Microsoft.EntityFrameworkCore;
using Storage.DataBase.EntityTypeConfigurations;

namespace Storage.DataBase.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductsBatchConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new ReportItemConfiguration());
        }
    }
}