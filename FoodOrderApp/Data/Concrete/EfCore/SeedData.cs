using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void CreateTestData(IApplicationBuilder app){
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<AppDbContext>();
            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }
                if(context.Categories.Any()){
                    context.Categories.AddRange(
                        new Entity.Category(CategoryName = "Kore", CategoryImage ="1.svg", CategoryDescription ="Otantik Kore yemekleri"),
                        new Entity.Category(CategoryName = "Pizza", CategoryImage ="2.svg", CategoryDescription ="Birbirinden leziz pizzalar"),
                    );
                    context.SaveChanges();
                }
                if(context.Products.Any()){
                    context.Products.AddRange(
                        new Entity.Product()
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}