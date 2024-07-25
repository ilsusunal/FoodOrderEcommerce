using FoodOrderApp.Data.Abstract;
using FoodOrderApp.DTOs;
using FoodOrderApp.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int? category)
        {
            var products = await _productRepository.GetAllAsync();
            if (category.HasValue)
            {
                products = products.Where(p => p.CategoryId == category.Value).ToList();
            }
            var productDtos = products.Select(MapToDto);
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(MapToDto(product));
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string query)
        {
            var products = await _productRepository.GetAllAsync();
            var filteredProducts = products.Where(p => p.ProductName.Contains(query, StringComparison.OrdinalIgnoreCase));
            var productDtos = filteredProducts.Select(MapToDto);
            return Ok(productDtos);
        }

        [HttpPost]
        [Route("admin/products")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (!User.IsInRole("Admin"))
            {
                return BadRequest(); 
            }
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId
            };

            await _productRepository.AddAsync(product);
            var createdProductDto = MapToDto(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, createdProductDto);
        }

        [HttpPut]
        [Route("admin/products/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!User.IsInRole("Admin"))
            {
                return BadRequest(); 
            }
            if (id != productDto.ProductId)
            {
                return BadRequest();
            }

            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = productDto.ProductName;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.CategoryId = productDto.CategoryId;

            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete]
        [Route("admin/products/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                return BadRequest(); 
            }
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
