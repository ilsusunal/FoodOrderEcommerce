namespace FoodOrderApp.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int PhoneNumber { get; set; }
        public List<UserCard> UserCards { get; set; } = new List<UserCard>();
        public List<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public List<ShoppingCart> Orders{ get; set; }= new List<ShoppingCart>();

    }
}