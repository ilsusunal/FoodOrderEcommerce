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

            }
        }
    }
}
