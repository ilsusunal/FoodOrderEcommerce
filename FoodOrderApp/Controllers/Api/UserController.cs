using FoodOrderApp.Data.Abstract;
using FoodOrderApp.Entity;
using FoodOrderApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodOrderApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(IUserRepository<User> userRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User registered successfully" });
            }

            return BadRequest(result.Errors);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Ok(new { Message = "Login successful" });
            }

            return Unauthorized("Invalid login attempt");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { Message = "Logout successful" });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpGet("addresses")]
        public async Task<IActionResult> GetUserAddresses([FromQuery] string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.UserAddresses);
        }

        [HttpPost("addresses")]
        public async Task<IActionResult> AddUserAddress([FromQuery] string userId, [FromBody] UserAddress userAddress)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.UserAddresses.Add(userAddress);
            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpPut("addresses/{id}")]
        public async Task<IActionResult> UpdateUserAddress(int id, [FromBody] UserAddress updatedAddress)
        {
            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(u => u.UserAddresses.Any(ua => ua.Id == id));

            if (user == null)
            {
                return NotFound();
            }

            var address = user.UserAddresses.FirstOrDefault(ua => ua.Id == id);
            if (address != null)
            {
                address.Address = updatedAddress.Address;
                await _userRepository.UpdateAsync(user);
            }
            return NoContent();
        }

        [HttpDelete("addresses/{id}")]
        public async Task<IActionResult> DeleteUserAddress(int id)
        {
            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(u => u.UserAddresses.Any(ua => ua.Id == id));

            if (user == null)
            {
                return NotFound();
            }

            var address = user.UserAddresses.FirstOrDefault(ua => ua.Id == id);
            if (address != null)
            {
                user.UserAddresses.Remove(address);
                await _userRepository.UpdateAsync(user);
            }
            return NoContent();
        }

        [HttpGet("cards")]
        public async Task<IActionResult> GetUserCards([FromQuery] string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.UserCards);
        }

        [HttpPost("cards")]
        public async Task<IActionResult> AddUserCard([FromQuery] string userId, [FromBody] UserCard userCard)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.UserCards.Add(userCard);
            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpPut("cards/{id}")]
        public async Task<IActionResult> UpdateUserCard(int id, [FromBody] UserCard updatedCard)
        {
            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(u => u.UserCards.Any(uc => uc.Id == id));

            if (user == null)
            {
                return NotFound();
            }

            var card = user.UserCards.FirstOrDefault(uc => uc.Id == id);
            if (card != null)
            {
                card.Card = updatedCard.Card;
                await _userRepository.UpdateAsync(user);
            }
            return NoContent();
        }

        [HttpDelete("cards/{id}")]
        public async Task<IActionResult> DeleteUserCard(int id)
        {
            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(u => u.UserCards.Any(uc => uc.Id == id));

            if (user == null)
            {
                return NotFound();
            }

            var card = user.UserCards.FirstOrDefault(uc => uc.Id == id);
            if (card != null)
            {
                user.UserCards.Remove(card);
                await _userRepository.UpdateAsync(user);
            }
            return NoContent();
        }
        
    }
}
