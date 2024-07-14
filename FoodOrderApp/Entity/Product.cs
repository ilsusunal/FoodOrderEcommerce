namespace FoodOrderApp.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set;}
        public string? ProductImage { get; set;}
        public float Price { get; set; }
        public string? Description { get; set; }
        public string? Materials { get; set; }
    }
}