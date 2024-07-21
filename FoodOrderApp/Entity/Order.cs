namespace FoodOrderApp.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; } = null!;
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public Payment Payment { get; set; } = null!;
    }
}