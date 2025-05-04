using Storage.Core.Models;

namespace Storage.Core.Services
{
    public interface IReportsService
    {
        Report CreateReport(IEnumerable<ProductsBatch> productsBatches);
    
        IEnumerable<Report> GetReports();

        Report? GetReport(Guid id);

        Report? GetLastReport();
    }
}