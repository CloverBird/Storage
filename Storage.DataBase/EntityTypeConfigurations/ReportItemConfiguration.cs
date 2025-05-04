using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Core.Models;

namespace Storage.DataBase.EntityTypeConfigurations
{
    public class ReportItemConfiguration : IEntityTypeConfiguration<ReportItem>
    {
        public void Configure(EntityTypeBuilder<ReportItem> builder)
        {
            builder.HasKey(ri => ri.Id);

            builder.HasOne(ri => ri.Report)
                .WithMany(r => r.ReportItems);

            builder.HasOne(ri => ri.ProductsBatch)
                .WithMany()
                .HasForeignKey(ri => ri.ProductsBatchId);

            builder.ToTable("ReportItems");
        }
    }
}