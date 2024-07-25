using FoodOrderApp.Data.Abstract;
using FoodOrderApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodOrderApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int? category)
        {
            if (category.HasValue)
            {
                var products = await _productRepository.GetAllAsync();
                return Ok(products.Where(p => p.CategoryId == category.Value));
            }
            return Ok(await _productRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string query)
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products.Where(p => p.ProductName.Contains(query, StringComparison.OrdinalIgnoreCase)));
        }

        [HttpPost]
        [Route("admin/products")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpPut]
        [Route("admin/products/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete]
        [Route("admin/products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
