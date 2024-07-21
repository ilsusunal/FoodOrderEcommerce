namespace FoodOrderApp.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set;}
        public string? ProductImage { get; set;}
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Materials { get; set; }
        public int CategoryId { get; set; }
        public Category Category{ get; set; } = null!;
        public List<ProductVar> Variations { get; set; } = new List<ProductVar>();
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}