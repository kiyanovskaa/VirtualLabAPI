using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VirtualLabAPI.Handler;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarterDiagramController : Controller
    {
        private static readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Source", "StarterDiagrams.txt"); // Шлях до файлу з JSON


        [HttpGet("{id}")]
        public ActionResult<StarterDiagram> GetById(int id)
        {
            try
            {
                List<StarterDiagram> diagrams = FileHandler<StarterDiagram>.ReadFromFile(FilePath);

                var diagram = diagrams?.Find(d => d.id == id);

                if (diagram == null)
                {
                    return NotFound($"Diagram with ID {id} not found.");
                }

                return Ok(diagram);
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
