namespace FoodOrderApp.Entity
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; } = null!;
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}