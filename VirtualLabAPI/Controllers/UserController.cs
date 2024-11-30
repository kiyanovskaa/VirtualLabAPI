using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using VirtualLabAPI.Handler;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private static readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Source", "User.txt"); // Шлях до файлу з даними

        [HttpGet("id/{id}")]
        public IActionResult GetUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid User ID. User ID must be greater than 0.");
            }


            if (id <= 0)
            {
                return BadRequest("Invalid ID. ID must be greater than 0.");
            }
            List<User> users = FileHandler<User>.ReadFromFile(FilePath);
            var result = users?.Find(t => t.Id == id);

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LogIn loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.Username) || string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return BadRequest("Username and Password are required.");
            }

            List<User> users = FileHandler<User>.ReadFromFile(FilePath);

            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }
            string hashedPassword = HashPassword.Hash(loginRequest.Password);

            var user = users.FirstOrDefault(u => u.Username == loginRequest.Username && u.PasswordHash == hashedPassword);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var result = new
            {
                user.Id,
                user.Username,
                user.Email,
                user.Role,
                user.FirstName,
                user.LastName
            };

            return Ok(result);
        }
    }
}