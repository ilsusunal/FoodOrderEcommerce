using Microsoft.AspNetCore.Identity;

namespace FoodOrderApp.Entity
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public List<UserCard> UserCards { get; set; } = new List<UserCard>();
        public List<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public List<ShoppingCart> Orders{ get; set; }= new List<ShoppingCart>();

    }
}