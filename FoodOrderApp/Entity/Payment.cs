namespace FoodOrderApp.Entity
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; } //cargo fee
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; } // card, at the door 
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int? CardId { get; set; }
        public Card? Card { get; set; }
    }
}