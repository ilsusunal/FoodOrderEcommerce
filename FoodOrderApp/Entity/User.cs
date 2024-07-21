namespace FoodOrderApp.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int PhoneNumber { get; set; }
        public List<Card> Cards{ get; set; } = new List<Card>();
        public List<Address> AddressList{ get; set;} = new List<Address>();
        public List<Order> Orders{ get; set; }= new List<Order>();

    }
}