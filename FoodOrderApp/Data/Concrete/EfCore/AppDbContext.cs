using FoodOrderApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderApp.Data.Concrete.EfCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<User> Users => Set<User>();
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductVar> ProductVars => Set<ProductVar>();
        public DbSet<Material> Materials => Set<Material>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
        public DbSet<Payment> Payments => Set<Payment>();
    }
}