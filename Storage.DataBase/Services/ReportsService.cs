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

            _dbContext.Add(report);
            _dbContext.SaveChanges();

            return report;
        }

        public Report? GetLastReport()
        {
            throw new NotImplementedException();
        }

        public Report? GetReport(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetReports()
        {
            throw new NotImplementedException();
        }
    }
}