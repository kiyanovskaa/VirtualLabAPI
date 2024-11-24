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
        private static readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Source", "Tasks.txt"); // Шлях до файлу з даними

        // Метод для отримання задачі за ID
        [HttpGet("byId/{id}")]
        public ActionResult<Assignement> GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID. ID must be greater than 0.");
                }
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

        [HttpGet("byStudentId/{studentId}")]
        public ActionResult<Assignement> GetByStudentId(int studentId)
        {
            try
            {
                if (studentId <= 0)
                {
                    return BadRequest("Invalid Student ID. Student ID must be greater than 0.");
                }

                if (!System.IO.File.Exists(FilePath))
                {
                    return NotFound("Data file not found.");
                }

                List<Assignement> tasks = FileHandler<Assignement>.ReadFromFile(FilePath);
                var task = tasks?.FirstOrDefault(t => t.StudentId == studentId);

                if (task == null)
                {
                    return NotFound($"Task with Student ID {studentId} not found.");
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
