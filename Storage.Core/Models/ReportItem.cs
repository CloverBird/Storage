namespace Storage.Core.Models
{
    public class ReportItem
    {
        public Guid Id { get; set; }
        public required ProductsBatch ProductsBatch { get; set; }

        public required Report Report;
    }
}