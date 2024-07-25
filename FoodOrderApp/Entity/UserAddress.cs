namespace FoodOrderApp.Entity
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}