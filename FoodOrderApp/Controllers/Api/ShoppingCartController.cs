using FoodOrderApp.Data.Abstract;
using FoodOrderApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodOrderApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;

        public ShoppingCartController(IRepository<ShoppingCart> shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart([FromQuery] string userId)
        {
            var cart = await _shoppingCartRepository.GetAllAsync();
            return Ok(cart.FirstOrDefault(c => c.UserId == userId));
        }

        [HttpPost]
        [Route("products/{id}")]
        public async Task<IActionResult> AddProductToCart(int id, [FromBody] CartProduct cartProduct)
        {
            var cart = await _shoppingCartRepository.GetByIdAsync(cartProduct.CartId);
            if (cart == null)
            {
                return NotFound();
            }

            cart.CartProducts.Add(cartProduct);
            await _shoppingCartRepository.UpdateAsync(cart);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCart([FromBody] ShoppingCart cart)
        {
            await _shoppingCartRepository.UpdateAsync(cart);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProductFromCart(int id)
        {
            var cart = await _shoppingCartRepository.GetByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == id);
            if (cartProduct != null)
            {
                cart.CartProducts.Remove(cartProduct);
                await _shoppingCartRepository.UpdateAsync(cart);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("order")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            await _shoppingCartRepository.UpdateAsync(order.Cart);
            return CreatedAtAction(nameof(GetCart), new { userId = order.Cart.UserId }, order);
        }
    }
}
