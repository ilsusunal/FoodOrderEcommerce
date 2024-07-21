namespace FoodOrderApp.Entity
{
    public class Address
    {
        public int AddressId { get; set; }
        public string? AddressName { get; set;}
        public string? AddressType { get; set;}
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Street { get; set; }
        public int AptNo { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}