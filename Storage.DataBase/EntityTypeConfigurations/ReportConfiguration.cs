using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Core.Models;

namespace Storage.DataBase.EntityTypeConfigurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.GeneratedAt)
                .IsRequired();
            
            builder.HasMany(r => r.ReportItems)
                .WithOne(ri => ri.Report)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Reports");
        }
    }
}