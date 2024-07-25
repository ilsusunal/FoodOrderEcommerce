using FoodOrderApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static async Task CreateTestData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (context != null)
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                        Console.WriteLine("Database migrated.");
                    }

                    await SeedRoles(roleManager);
                    await SeedUsers(userManager);
                    await SeedCategories(context);
                    await SeedProducts(context);
                    await SeedAddresses(context);
                    await SeedCards(context);
                    await SeedShoppingCarts(context);
                }
            }
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                Console.WriteLine("Admin role created.");
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
                Console.WriteLine("User role created.");
            }
        }

        private static async Task SeedUsers(UserManager<User> userManager)
        {
            var users = new[]
            {
        new User { UserName = "john@example.com", FullName = "John Doe", Email = "john@example.com" },
        new User { UserName = "jane@example.com", FullName = "Jane Doe", Email = "jane@example.com" },
        new User { UserName = "ilsu@example.com", FullName = "İlsu Admin", Email = "ilsu@example.com" }
    };

            foreach (var user in users)
            {
                var password = "Password!123";

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    var role = user.Email == "ilsu@example.com" ? "Admin" : "User";
                    await userManager.AddToRoleAsync(user, role);
                    Console.WriteLine($"User '{user.UserName}' created and assigned to role '{role}'.");
                }
                else
                {
                    Console.WriteLine($"Failed to create user '{user.UserName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }


        private static async Task SeedCategories(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryName = "Kore", CategoryImage = "1.svg", CategoryDescription = "Otantik Kore yemekleri" },
                    new Category { CategoryName = "Pizza", CategoryImage = "2.svg", CategoryDescription = "Birbirinden leziz pizzalar" },
                    new Category { CategoryName = "Burger", CategoryImage = "3.svg", CategoryDescription = "Müthiş burgerler" },
                    new Category { CategoryName = "Kızartmalar", CategoryImage = "4.svg", CategoryDescription = "Enfes atıştırmalıklar" },
                    new Category { CategoryName = "Fast Food", CategoryImage = "5.svg", CategoryDescription = "Lezzetli menü seçenekleri" },
                    new Category { CategoryName = "İçecek", CategoryImage = "6.svg", CategoryDescription = "Yemeğin yanına müthiş giden içecekler" }
                );
                await context.SaveChangesAsync();
                Console.WriteLine("Categories seeded.");
            }
        }

        private static async Task SeedProducts(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                var categories = context.Categories.ToList();
                var koreCategory = categories.FirstOrDefault(c => c.CategoryName == "Kore");
                var pizzaCategory = categories.FirstOrDefault(c => c.CategoryName == "Pizza");
                var burgerCategory = categories.FirstOrDefault(c => c.CategoryName == "Burger");

                if (koreCategory != null && pizzaCategory != null && burgerCategory != null)
                {
                    context.Products.AddRange(
                        new Product { ProductName = "Spicy Korean Noodles", ProductImage = "food-4.png", Price = 120, Description = "Delicious and spicy Korean noodles", CategoryId = koreCategory.CategoryId },
                        new Product { ProductName = "Terminal Pizza", ProductImage = "food-1.png", Price = 120, Description = "Delicious Terminal Pizza", CategoryId = pizzaCategory.CategoryId },
                        new Product { ProductName = "Position absolute Acı Pizza", ProductImage = "food-1.png", Price = 120, Description = "Delicious and spicy pizza", CategoryId = pizzaCategory.CategoryId },
                        new Product { ProductName = "useEffect Tavuklu Burger", ProductImage = "food-3.png", Price = 120, Description = "Delicious burger with chicken", CategoryId = burgerCategory.CategoryId }
                    );
                    await context.SaveChangesAsync();
                    Console.WriteLine("Products seeded.");
                }
                else
                {
                    Console.WriteLine("Could not find necessary categories for seeding products.");
                }
            }
        }

        private static async Task SeedAddresses(AppDbContext context)
        {
            if (!context.Addresses.Any())
            {
                context.Addresses.AddRange(
                    new Address { AddressName = "Home", City = "Istanbul", District = "Kadikoy", Neighbourhood = "Moda", Street = "Sahil Yolu", AptNo = 1 },
                    new Address { AddressName = "Office", City = "Ankara", District = "Cankaya", Neighbourhood = "Kizilay", Street = "Ataturk Bulvari", AptNo = 2 }
                );
                await context.SaveChangesAsync();
                Console.WriteLine("Addresses seeded.");
            }
        }

        private static async Task SeedCards(AppDbContext context)
        {
            if (!context.Cards.Any())
            {
                context.Cards.AddRange(
                    new Card { CardNo = 1234567890123456, ExpireMonth = 12, ExpireYear = 2025, NameOnCard = "John Doe" },
                    new Card { CardNo = 6543210987654321, ExpireMonth = 11, ExpireYear = 2023, NameOnCard = "Jane Doe" }
                );
                await context.SaveChangesAsync();
                Console.WriteLine("Cards seeded.");
            }
        }

        private static async Task SeedShoppingCarts(AppDbContext context)
        {
            if (!context.ShoppingCarts.Any())
            {
                var users = context.Users.ToList();
                var user1 = users.FirstOrDefault(u => u.Email == "john@example.com");
                var user2 = users.FirstOrDefault(u => u.Email == "jane@example.com");

                if (user1 != null && user2 != null)
                {
                    context.ShoppingCarts.AddRange(
                        new ShoppingCart { TotalAmount = 0, UserId = user1.Id },
                        new ShoppingCart { TotalAmount = 0, UserId = user2.Id }
                    );
                    await context.SaveChangesAsync();
                    Console.WriteLine("Shopping carts seeded.");
                }
                else
                {
                    Console.WriteLine("Could not find necessary users for seeding shopping carts.");
                }
            }
        }
    }
}
