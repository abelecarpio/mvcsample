namespace MvcSample.Entities
{
    public class CustomerCard
    {
        public long CustomerCardId { get; set; }
        public long CustomerId { get; set; }
        public string CardNumber { get; set; }
        public decimal CreditLimit { get; set; }
    }
}