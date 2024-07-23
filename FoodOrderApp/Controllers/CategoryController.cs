using Microsoft.AspNetCore.Mvc;
using FoodOrderApp.Data;
using FoodOrderApp.Entity;

namespace FoodOrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return Ok(_categoryRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound(new { Message = $"Category with ID {id} not found." });
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
        {
            _categoryRepository.Add(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            try
            {
                _categoryRepository.Update(category);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Category with ID {id} not found." });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _categoryRepository.Delete(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Category with ID {id} not found." });
            }

            return NoContent();
        }
    }
}
