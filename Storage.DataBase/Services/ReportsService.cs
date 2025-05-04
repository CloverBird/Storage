using Microsoft.EntityFrameworkCore;
using Storage.Core.Models;
using Storage.Core.Services;
using Storage.DataBase.DbContexts;

namespace Storage.DataBase.Services
{
    public class ReportsService : IReportsService
    {
        private readonly AppDbContext _dbContext;
        protected DbSet<Report> Reports => _dbContext.Set<Report>();

        public ReportsService(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Report CreateReport(IEnumerable<ProductsBatch> productsBatches)
        {
            var report = new Report {
                Id = Guid.NewGuid(),
                GeneratedAt = DateTime.UtcNow,
                ReportItems = null
            };

            report.ReportItems = productsBatches.Select(p => new ReportItem {
                    Id = Guid.NewGuid(),
                    ProductsBatch = p,
                    Report = report
                }).ToList();

            Reports.Add(report);
            _dbContext.SaveChanges();

            return report;
        }

        public Report? GetLastReport()
        {
            return Reports
                .Include(r => r.ReportItems)
                    .ThenInclude(ri => ri.ProductsBatch)
                .OrderByDescending(r => r.GeneratedAt)
                .FirstOrDefault();
        }

        public Report? GetReport(Guid id) => Reports.AsNoTracking().FirstOrDefault(r => r.Id == id);

        public IEnumerable<Report> GetReports()
        {
            return Reports.AsNoTracking();
        }
    }
}