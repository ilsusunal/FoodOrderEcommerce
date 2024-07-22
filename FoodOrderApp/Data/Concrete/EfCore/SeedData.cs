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
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Entity.Category
                        {
                            CategoryName = "Kore",
                            //CategoryImage = "1.svg",
                            CategoryDescription = "Otantik Kore yemekleri"
                        },
                        new Entity.Category
                        {
                            CategoryName = "Pizza",
                            //CategoryImage = "2.svg",
                            CategoryDescription = "Birbirinden leziz pizzalar"
                        },
                        new Entity.Category
                        {
                            CategoryName = "Burger",
                            //CategoryImage = "3.svg",
                            CategoryDescription = "Müthiş burgerler"
                        }, new Entity.Category
                        {
                            CategoryName = "Kızartmalar",
                            //CategoryImage = "4.svg",
                            CategoryDescription = "Enfes atıştırmalıklar"
                        },
                        new Entity.Category
                        {
                            CategoryName = "Fast Food",
                            //CategoryImage = "5.svg",
                            CategoryDescription = "Lezzetli menü seçenekleri"
                        },
                        new Entity.Category
                        {
                            CategoryName = "İçecek",
                            //CategoryImage = "6.svg",
                            CategoryDescription = "Yemeğin yanına müthiş giden içecekler"
                        }
                    );
                    context.SaveChanges();
                }
                // Seed Products
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
                                Price = 120,
                                Description = "Delicious and spicy Korean noodles",
                                CategoryId = koreCategory.CategoryId
                            },
                            new Entity.Product
                            {
                                ProductName = "Terminal Pizza",
                                Price = 120,
                                Description = "Delicious Terminal Pizza",
                                CategoryId = pizzaCategory.CategoryId
                            },
                            new Entity.Product
                            {
                                ProductName = "Position absolute Acı Pizza",
                                Price = 120,
                                Description = "Delicious and spicy pizza",
                                CategoryId = pizzaCategory.CategoryId
                            },
                            new Entity.Product
                            {
                                ProductName = "useEffect Tavuklu Burger",
                                Price = 120,
                                Description = "Delicious burger with chicken",
                                CategoryId = burgerCategory.CategoryId
                            }
                        );
                        context.SaveChanges();
                    }
                }

                // Seed Users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new Entity.User
                        {
                            UserName = "john_doe",
                            FullName = "John Doe",
                            Email = "john.doe@example.com",
                            Password = "hashed_password", // Use hashed password in real applications
                            PhoneNumber = 1234567890,
                            AddressList = new List<Entity.Address>
                            {
                                new Entity.Address
                                {
                                    AddressName = "Home",
                                    AddressType = "Residential",
                                    City = "New York",
                                    District = "Manhattan",
                                    Neighbourhood = "Upper East Side",
                                    Street = "5th Avenue",
                                    AptNo = 101
                                }
                            },
                            Cards = new List<Entity.Card>
                            {
                                new Entity.Card
                                {
                                    CardNo = 1234567812345678,
                                    ExpireMonth = 12,
                                    ExpireYear = 2025,
                                    NameOnCard = "John Doe"
                                }
                            }
                        }
                    );
                    context.SaveChanges();
                }

                // Seed Materials
                if (!context.Materials.Any())
                {
                    context.Materials.AddRange(
                        new Entity.Material
                        {
                            MaterialName = "Cheese",
                            Price = 20,
                            IsVegetarian = true
                        },
                        new Entity.Material
                        {
                            MaterialName = "Pepperoni",
                            Price = 30,
                            IsVegetarian = false
                        }
                    );
                    context.SaveChanges();
                }

                // Seed ProductVars
                if (!context.ProductVars.Any())
                {
                    var pepperoniPizza = context.Products.FirstOrDefault(p => p.ProductName == "Terminal Pizza");
                    var materials = context.Materials.ToList();

                    if (pepperoniPizza != null && materials.Any())
                    {
                        context.ProductVars.AddRange(
                            new Entity.ProductVar
                            {
                                ProductId = pepperoniPizza.ProductId,
                                Price = 150,
                                Materials = materials
                            }
                        );
                        context.SaveChanges();
                    }
                }

                // Seed Orders and Payments
                if (!context.Orders.Any())
                {
                    var user = context.Users.FirstOrDefault();
                    var product = context.Products.FirstOrDefault();

                    if (user != null && product != null)
                    {
                        var order = new Entity.Order
                        {
                            TotalAmount = 150,
                            UserId = user.UserId,
                            OrderProducts = new List<Entity.OrderProduct>
                            {
                                new Entity.OrderProduct
                                {
                                    ProductId = product.ProductId,
                                    Quantity = 1,
                                    Price = product.Price
                                }
                            }
                        };

                        context.Orders.Add(order);
                        context.SaveChanges();

                        var payment = new Entity.Payment
                        {
                            Amount = 150,
                            PaymentDate = DateTime.UtcNow,
                            PaymentMethod = "Card",
                            OrderId = order.OrderId,
                            CardId = user.Cards.FirstOrDefault()?.CardId // Handle case where there might be no cards
                        };

                        context.Payments.Add(payment);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
