namespace FoodOrderApp.Entity
{
    public class CartProduct
    {
        public int CartProductId { get; set; }
        public int CartId { get; set; }
        public ShoppingCart Cart { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}