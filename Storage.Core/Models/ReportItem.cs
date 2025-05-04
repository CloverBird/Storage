namespace Storage.Core.Models
{
    public class ReportItem
    {
        public Guid Id { get; set; }
        public ProductsBatch ProductsBatch { get; set; }
        public Guid ProductsBatchId { get; set;}

        public required Report Report;
    }
}