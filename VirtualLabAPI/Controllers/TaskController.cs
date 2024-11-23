using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VirtualLabAPI.Handler;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private const string FilePath = "E:\\pz4_1\\VirtualLabWebApi\\VirtualLabAPI\\VirtualLabAPI\\Source\\Tasks.txt"; // Шлях до файлу з даними

        // Метод для отримання задачі за ID
        [HttpGet("{id}")]
        public ActionResult<Assignement> GetById(int id)
        {
            try
            {
                List<Assignement> tasks = FileHandler<Assignement>.ReadFromFile(FilePath);
                var task = tasks?.Find(t => t.Id == id);

                if (task == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }

                return Ok(task);
            }
            catch (JsonException)
            {
                return BadRequest("Failed to parse JSON file.");
            }
            catch (IOException ex)
            {
                return StatusCode(500, $"Error reading file: {ex.Message}");
            }
        }
    }
}
