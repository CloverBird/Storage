namespace Storage.Core.Models
{
    public class ProductsBatch
    {
        public Guid Id { get; set; }
        public required string ProductName { get; set; }
        public string? ProductDescription { get; set; } 
        public required double ProductPrice { get; set; }
        public required DateOnly ProducingDate { get; set; }
        public required DateOnly ExpirationDate { get; set; }
        public int? Discount { get; set; }
        public required int Quantity { get; set; }
                
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

        public double PriceWithDiscount {
            get {
                return Discount == null ?
                    ProductPrice : 
                    ProductPrice - ProductPrice * ((double)Discount / 100);
            }
        }

        public ProductsBatch Clone() => new ProductsBatch {
            Id = Id,
            ProductName = ProductName,
            ProductDescription = ProductDescription,
            ProductPrice = ProductPrice,
            Discount = Discount,
            ProducingDate = ProducingDate,
            ExpirationDate = ExpirationDate,
            Quantity = Quantity
        };

        public ProductsBatch CloneWithNewId() => new ProductsBatch {
            Id = Guid.NewGuid(),
            ProductName = ProductName,
            ProductDescription = ProductDescription,
            ProductPrice = ProductPrice,
            Discount = Discount,
            ProducingDate = ProducingDate,
            ExpirationDate = ExpirationDate,
            Quantity = Quantity
        };
    }
}