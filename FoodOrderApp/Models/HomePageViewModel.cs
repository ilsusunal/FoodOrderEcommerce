using FoodOrderApp.Entity;

namespace FoodOrderApp.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
