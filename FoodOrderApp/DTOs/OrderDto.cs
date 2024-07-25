using FoodOrderApp.Entity;

namespace FoodOrderApp.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderMethod OrderMethod { get; set; }
        public int? CardId { get; set; } 
        public int AddressId { get; set; }
    }
}
