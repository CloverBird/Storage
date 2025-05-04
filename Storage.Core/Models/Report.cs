namespace Storage.Core.Models
{
    public class Report
    {
        public Guid Id { get; set; }

        public DateTime GeneratedAt { get; set; }

        public List<ReportItem> ReportItems { get; set; } = [];
    }
}