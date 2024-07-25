using FoodOrderApp.Data.Abstract;
using FoodOrderApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodOrderApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpGet]
        [Route("addresses")]
        public async Task<IActionResult> GetUserAddresses([FromQuery] int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.UserAddresses);
        }

        [HttpPost]
        [Route("addresses")]
        public async Task<IActionResult> AddUserAddress([FromQuery] int userId, [FromBody] Address address)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.UserAddresses.Add(new UserAddress { User = user, Address = address });
            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpPut]
        [Route("addresses/{id}")]
        public async Task<IActionResult> UpdateUserAddress(int id, [FromBody] Address address)
        {
            var user = await _userRepository.GetByIdAsync(address.UserAddresses.FirstOrDefault(ua => ua.Id == id).UserId);
            if (user == null)
            {
                return NotFound();
            }

            var userAddress = user.UserAddresses.FirstOrDefault(ua => ua.Id == id);
            if (userAddress != null)
            {
                userAddress.Address = address;
                await _userRepository.UpdateAsync(user);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("addresses/{id}")]
        public async Task<IActionResult> DeleteUserAddress(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userAddress = user.UserAddresses.FirstOrDefault(ua => ua.Id == id);
            if (userAddress != null)
            {
                user.UserAddresses.Remove(userAddress);
                await _userRepository.UpdateAsync(user);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("cards")]
        public async Task<IActionResult> GetUserCards([FromQuery] int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.UserCards);
        }

        [HttpPost]
        [Route("cards")]
        public async Task<IActionResult> AddUserCard([FromQuery] int userId, [FromBody] Card card)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.UserCards.Add(new UserCard { User = user, Card = card });
            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpPut]
        [Route("cards/{id}")]
        public async Task<IActionResult> UpdateUserCard(int id, [FromBody] Card card)
        {
            var user = await _userRepository.GetByIdAsync(card.UserCards.FirstOrDefault(uc => uc.Id == id).UserId);
            if (user == null)
            {
                return NotFound();
            }

            var userCard = user.UserCards.FirstOrDefault(uc => uc.Id == id);
            if (userCard != null)
            {
                userCard.Card = card;
                await _userRepository.UpdateAsync(user);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("cards/{id}")]
        public async Task<IActionResult> DeleteUserCard(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userCard = user.UserCards.FirstOrDefault(uc => uc.Id == id);
            if (userCard != null)
            {
                user.UserCards.Remove(userCard);
                await _userRepository.UpdateAsync(user);
            }
            return NoContent();
        }
    }
}
