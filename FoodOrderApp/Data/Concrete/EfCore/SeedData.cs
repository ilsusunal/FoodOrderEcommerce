using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FoodOrderApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void CreateTestData(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<AppDbContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                //Categories
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Entity.Category
                        {
                            CategoryName = "Kore",
                            CategoryImage = "1.svg",
                            CategoryDescription = "Otantik Kore yemekleri"
                        },
                        new Entity.Category
                        {
                            CategoryName = "Pizza",
                            CategoryImage = "2.svg",
                            CategoryDescription = "Birbirinden leziz pizzalar"
                        },
                        new Entity.Category
                        {
                            CategoryName = "Burger",
                            CategoryImage = "3.svg",
                            CategoryDescription = "Müthiş burgerler"
                        }, new Entity.Category
                        {
                            CategoryName = "Kızartmalar",
                            CategoryImage = "4.svg",
                            CategoryDescription = "Enfes atıştırmalıklar"
                        },
                        new Entity.Category
                        {
                            CategoryName = "Fast Food",
                            CategoryImage = "5.svg",
                            CategoryDescription = "Lezzetli menü seçenekleri"
                        },
                        new Entity.Category
                        {
                            CategoryName = "İçecek",
                            CategoryImage = "6.svg",
                            CategoryDescription = "Yemeğin yanına müthiş giden içecekler"
                        }
                    );
                    context.SaveChanges();
                }
                // Products
                if (!context.Products.Any())
                {
                    var koreCategory = context.Categories.FirstOrDefault(c => c.CategoryName == "Kore");
                    var pizzaCategory = context.Categories.FirstOrDefault(c => c.CategoryName == "Pizza");
                    var burgerCategory = context.Categories.FirstOrDefault(c => c.CategoryName == "Burger");

                    if (koreCategory != null && pizzaCategory != null && burgerCategory != null)
                    {
                        context.Products.AddRange(
                            new Entity.Product
                            {
                                ProductName = "Spicy Korean Noodles",
                                ProductImage = "food-4.png",
                                Price = 120,
                                Description = "Delicious and spicy Korean noodles",
                                CategoryId = koreCategory.CategoryId
                            },
                            new Entity.Product
                            {
                                ProductName = "Terminal Pizza",
                                ProductImage = "food-1.png",
                                Price = 120,
                                Description = "Delicious Terminal Pizza",
                                CategoryId = pizzaCategory.CategoryId
                            },
                            new Entity.Product
                            {
                                ProductName = "Position absolute Acı Pizza",
                                ProductImage = "food-1.png",
                                Price = 120,
                                Description = "Delicious and spicy pizza",
                                CategoryId = pizzaCategory.CategoryId
                            },
                            new Entity.Product
                            {
                                ProductName = "useEffect Tavuklu Burger",
                                ProductImage = "food-3.png",
                                Price = 120,
                                Description = "Delicious burger with chicken",
                                CategoryId = burgerCategory.CategoryId
                            }
                        );
                        context.SaveChanges();
                    }
                }

                // Addresses
                if (!context.Addresses.Any())
                {
                    context.Addresses.AddRange(
                        new Entity.Address
                        {
                            AddressName = "Home",
                            City = "Istanbul",
                            District = "Kadikoy",
                            Neighbourhood = "Moda",
                            Street = "Sahil Yolu",
                            AptNo = 1
                        },
                        new Entity.Address
                        {
                            AddressName = "Office",
                            City = "Ankara",
                            District = "Cankaya",
                            Neighbourhood = "Kizilay",
                            Street = "Ataturk Bulvari",
                            AptNo = 2
                        }
                    );
                    context.SaveChanges();
                }

                // Cards
                if (!context.Cards.Any())
                {
                    context.Cards.AddRange(
                        new Entity.Card
                        {
                            CardNo = 1234567890123456,
                            ExpireMonth = 12,
                            ExpireYear = 2025,
                            NameOnCard = "John Doe"
                        },
                        new Entity.Card
                        {
                            CardNo = 6543210987654321,
                            ExpireMonth = 11,
                            ExpireYear = 2023,
                            NameOnCard = "Jane Doe"
                        }
                    );
                    context.SaveChanges();
                }

                // Users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new Entity.User
                        {
                            FullName = "John Doe",
                            Email = "john@example.com",
                            Password = "password123",
                            //PhoneNumber = 1234567890
                        },
                        new Entity.User
                        {
                            FullName = "Jane Doe",
                            Email = "jane@example.com",
                            Password = "password123",
                            //PhoneNumber = 9876543210
                        }
                    );
                    context.SaveChanges();
                }

                // ShoppingCart
                if (!context.ShoppingCarts.Any())
                {
                    var user1 = context.Users.FirstOrDefault(u => u.Email == "john@example.com");
                    var user2 = context.Users.FirstOrDefault(u => u.Email == "jane@example.com");

                    if (user1 != null && user2 != null)
                    {
                        context.ShoppingCarts.AddRange(
                            new Entity.ShoppingCart
                            {
                                TotalAmount = 0,
                                UserId = user1.UserId
                            },
                            new Entity.ShoppingCart
                            {
                                TotalAmount = 0,
                                UserId = user2.UserId
                            }
                        );
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
