using FoodOrderApp.Data;
using FoodOrderApp.Data.Abstract;
using FoodOrderApp.Data.Concrete;
using FoodOrderApp.Data.Concrete.EfCore;
using FoodOrderApp.Entity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

var app = builder.Build();


SeedData.CreateTestData(app);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Home
app.MapControllerRoute(
    name: "home",
    pattern: "/",
    defaults: new { controller = "Home", action = "Index" });

// Products
app.MapControllerRoute(
    name: "products",
    pattern: "products",
    defaults: new { controller = "Product", action = "GetProducts" });

app.MapControllerRoute(
    name: "product_details",
    pattern: "products/{id}",
    defaults: new { controller = "Product", action = "GetProduct" });

app.MapControllerRoute(
    name: "product_search",
    pattern: "products/search",
    defaults: new { controller = "Product", action = "SearchProducts" });

app.MapControllerRoute(
    name: "admin_create_product",
    pattern: "admin/products",
    defaults: new { controller = "Product", action = "CreateProduct" });

app.MapControllerRoute(
    name: "admin_update_product",
    pattern: "admin/products/{id}",
    defaults: new { controller = "Product", action = "UpdateProduct" });

app.MapControllerRoute(
    name: "admin_delete_product",
    pattern: "admin/products/{id}",
    defaults: new { controller = "Product", action = "DeleteProduct" });

// Categories
app.MapControllerRoute(
    name: "categories",
    pattern: "categories",
    defaults: new { controller = "Category", action = "GetCategories" });

app.MapControllerRoute(
    name: "category_details",
    pattern: "categories/{id}",
    defaults: new { controller = "Category", action = "GetCategory" });

app.MapControllerRoute(
    name: "admin_create_category",
    pattern: "admin/categories",
    defaults: new { controller = "Category", action = "CreateCategory" });

app.MapControllerRoute(
    name: "admin_update_category",
    pattern: "admin/categories/{id}",
    defaults: new { controller = "Category", action = "UpdateCategory" });

app.MapControllerRoute(
    name: "admin_delete_category",
    pattern: "admin/categories/{id}",
    defaults: new { controller = "Category", action = "DeleteCategory" });

// Orders
app.MapControllerRoute(
    name: "order_details",
    pattern: "order/{id}",
    defaults: new { controller = "Order", action = "GetOrder" });

app.MapControllerRoute(
    name: "create_order",
    pattern: "order",
    defaults: new { controller = "Order", action = "CreateOrder" });

app.MapControllerRoute(
    name: "update_order",
    pattern: "order/{id}",
    defaults: new { controller = "Order", action = "UpdateOrder" });

app.MapControllerRoute(
    name: "delete_order",
    pattern: "order/{id}",
    defaults: new { controller = "Order", action = "DeleteOrder" });

app.MapControllerRoute(
    name: "admin_orders",
    pattern: "admin/orders",
    defaults: new { controller = "Order", action = "GetOrders" });

// Shopping Cart
app.MapControllerRoute(
    name: "cart",
    pattern: "cart",
    defaults: new { controller = "ShoppingCart", action = "GetCart" });

app.MapControllerRoute(
    name: "add_to_cart",
    pattern: "cart/products/{id}",
    defaults: new { controller = "ShoppingCart", action = "AddProductToCart" });

app.MapControllerRoute(
    name: "update_cart",
    pattern: "cart",
    defaults: new { controller = "ShoppingCart", action = "UpdateCart" });

app.MapControllerRoute(
    name: "remove_from_cart",
    pattern: "cart/{id}",
    defaults: new { controller = "ShoppingCart", action = "RemoveProductFromCart" });

app.MapControllerRoute(
    name: "cart_order",
    pattern: "cart/order",
    defaults: new { controller = "ShoppingCart", action = "CreateOrder" });

// User Management
app.MapControllerRoute(
    name: "user_details",
    pattern: "user/{id}",
    defaults: new { controller = "User", action = "GetUser" });

app.MapControllerRoute(
    name: "update_user",
    pattern: "user/{id}",
    defaults: new { controller = "User", action = "UpdateUser" });

app.MapControllerRoute(
    name: "user_addresses",
    pattern: "user/addresses",
    defaults: new { controller = "User", action = "GetUserAddresses" });

app.MapControllerRoute(
    name: "add_user_address",
    pattern: "user/addresses",
    defaults: new { controller = "User", action = "AddUserAddress" });

app.MapControllerRoute(
    name: "update_user_address",
    pattern: "user/addresses/{id}",
    defaults: new { controller = "User", action = "UpdateUserAddress" });

app.MapControllerRoute(
    name: "delete_user_address",
    pattern: "user/addresses/{id}",
    defaults: new { controller = "User", action = "DeleteUserAddress" });

app.MapControllerRoute(
    name: "user_cards",
    pattern: "user/cards",
    defaults: new { controller = "User", action = "GetUserCards" });

app.MapControllerRoute(
    name: "add_user_card",
    pattern: "user/cards",
    defaults: new { controller = "User", action = "AddUserCard" });

app.MapControllerRoute(
    name: "update_user_card",
    pattern: "user/cards/{id}",
    defaults: new { controller = "User", action = "UpdateUserCard" });

app.MapControllerRoute(
    name: "delete_user_card",
    pattern: "user/cards/{id}",
    defaults: new { controller = "User", action = "DeleteUserCard" });


app.Run();