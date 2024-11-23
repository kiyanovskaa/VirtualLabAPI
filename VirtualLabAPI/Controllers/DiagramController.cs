using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VirtualLabAPI.Handler;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagramController : Controller
    {

        [HttpPost]
        public IActionResult CreateDiagram([FromBody] Diagram diagram)
        {
            if (diagram == null)
            {
                return BadRequest("Invalid diagram data.");
            }

            try
            {
               bool istrue= GradingHandler.Evaluate(diagram.classes, diagram.Id);

                if (istrue)
                {
                    return Ok("Diagram successfully added.");
                }
                else
                {
                    return BadRequest();    
                } 
            }
            catch (JsonException)
            {
                return BadRequest("Failed to parse diagram data.");
            }
            catch (IOException ex)
            {
                return StatusCode(500, $"Error writing to file: {ex.Message}");
            }
        }
    }
}
