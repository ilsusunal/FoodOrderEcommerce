using FoodOrderApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => {
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
