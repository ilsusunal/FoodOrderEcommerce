using FoodOrderApp.Data.Abstract;
using FoodOrderApp.Entity;
using FoodOrderApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodOrderApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;

        public HomeController(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet("")]
        [Route("home/index/{categoryId?}")]
        public async Task<IActionResult> Index(int? categoryId)
        {
            var categories = await _categoryRepository.GetAllAsync();
            IEnumerable<Product> products;

            if (categoryId.HasValue)
            {
                products = (await _productRepository.GetAllAsync()).Where(p => p.CategoryId == categoryId.Value);
            }
            else
            {
                products = await _productRepository.GetAllAsync();
            }

            var viewModel = new HomePageViewModel
            {
                Categories = categories,
                Products = products
            };

            return View(viewModel);
        }

    }
}
