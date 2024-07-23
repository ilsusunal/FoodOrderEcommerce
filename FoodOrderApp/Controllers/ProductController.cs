using FoodOrderApp.Data.Abstract;
using FoodOrderApp.DTOs;
using FoodOrderApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productRepository.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productRepository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct([FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var product = new Product
        {
            ProductName = productDto.ProductName,
            Price = productDto.Price,
            Description = productDto.Description,
            CategoryId = productDto.CategoryId
        };

        var createdProduct = await _productRepository.AddProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.ProductId }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] ProductDto productDto)
    {
        if (id != productDto.ProductId)
        {
            return BadRequest();
        }

        var product = new Product
        {
            ProductId = id,
            ProductName = productDto.ProductName,
            Price = productDto.Price,
            Description = productDto.Description,
            CategoryId = productDto.CategoryId
        };

        var updatedProduct = await _productRepository.UpdateProduct(product);
        if (updatedProduct == null)
        {
            return NotFound();
        }

        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var success = await _productRepository.DeleteProduct(id);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}
