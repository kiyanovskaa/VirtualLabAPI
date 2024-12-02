using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using VirtualLabAPI.Handler;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagramController : Controller
    {
        private List<IGradingHandler> _observers = new List<IGradingHandler>();
        public Diagram diag=new Diagram();


        public DiagramController()
        {
            // Створюємо об'єкт GradingHandler і додаємо до списку
            var gradingHandler = new GradingHandler();
            Attach(gradingHandler);
        }
        [HttpPost("{id}")]
        public IActionResult CreateDiagram(int id, [FromBody] Diagram diagram)
        {
            if (diagram == null)
            {
                return BadRequest("Invalid diagram data.");
            }

            try
            {
             
                Notify(diagram);
                
               // int istrue = GradingHandler.Evaluate(diagram.classes, diagram.Id);

                //return Ok(istrue);
                return Ok();
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
        private void Attach(IGradingHandler observer)
        {
            this._observers.Add(observer);
        }

        private void Detach(IGradingHandler observer)
        {
            this._observers.Remove(observer);
        }
      
        private void Notify(Diagram diagram)
        {
            foreach (var observer in _observers)
            {
                observer.Update(diagram);
            }

        }
    }
}
