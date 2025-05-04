using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Storage.Core.Models;

namespace Storage.DataBase.EntityTypeConfigurations
{
    public class ProductsBatchConfiguration : IEntityTypeConfiguration<ProductsBatch>
    {
        public void Configure(EntityTypeBuilder<ProductsBatch> builder)
        {
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d)
            );

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ProductDescription)
                .HasMaxLength(500);

            builder.Property(p => p.ProductPrice)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(p => p.ProducingDate)
                .HasConversion(dateOnlyConverter)
                .IsRequired();

            builder.Property(p => p.ExpirationDate)
                .HasConversion(dateOnlyConverter)
                .IsRequired();

            builder.Property(p => p.Discount);

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Ignore(p => p.State);
            builder.Ignore(p => p.PriceWithDiscount);

            builder.ToTable("ProductsBatches");
        }
    }
}