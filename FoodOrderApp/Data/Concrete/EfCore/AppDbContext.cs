using FoodOrderApp.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderApp.Data.Concrete.EfCore
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductVar> ProductVars => Set<ProductVar>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<CartProduct> CartProducts => Set<CartProduct>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<UserAddress> UserAddresses => Set<UserAddress>();
        public DbSet<UserCard> UserCards => Set<UserCard>();
    }
}