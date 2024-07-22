using Microsoft.AspNetCore.Mvc;

namespace FoodOrderApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}