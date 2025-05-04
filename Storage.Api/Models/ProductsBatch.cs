namespace Storage.Api.Models
{
    public class ProductsBatch
    {
        public Guid Id { get; set; }
        public required string ProductName { get; set; }
        public string? ProductDescription { get; set; } 
        public required double ProductPrice { get; set; }
        public required DateOnly ExpirationDate { get; set; }
        public required DateOnly ProducingDate { get; set; }
        public double? Discount { get; set; }
        public State State { 
            get {
                var today = DateOnly.FromDateTime(DateTime.Today);
                var totalDays = ExpirationDate.DayNumber - ProducingDate.DayNumber;
                var daysPassed = today.DayNumber - ProducingDate.DayNumber;
                
                if (ExpirationDate < today)
                    return State.Spoiled;
                else if ((double)daysPassed / totalDays >= 0.9)
                    return State.SoonSpoiled;

                else return State.Fresh;
            } 
        }

        public int Quantity { get; set; }
    }
}