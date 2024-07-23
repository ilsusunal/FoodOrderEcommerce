namespace FoodOrderApp.Entity
{
    public enum OrderMethod {
        Door, Card
    }
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderMethod OrderMethod { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart Cart { get; set; } = null!;
        public int? CardId { get; set; }
        public Card? Card { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
    }
}