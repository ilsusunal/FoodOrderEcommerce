using FoodOrderApp.Data.Abstract;
using FoodOrderApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodOrderApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [Route("admin/categories")]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            await _categoryRepository.AddAsync(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
        }

        [HttpPut]
        [Route("admin/categories/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            await _categoryRepository.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete]
        [Route("admin/categories/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
