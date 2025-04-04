using AspVetMedForEnimals.Interfaces;
using AspVetMedForEnimals.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspVetMedForEnimals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        IService _serviceService;
        public ServicesController(IService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]
        public List<Service> GetAll()
        {
            return _serviceService.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_serviceService.Get(id) == null)
            {
                return NotFound();
            }
            return Ok(_serviceService.Get(id));
        }
        

        [HttpPost]
        public IActionResult Post(string name, int durationMinutes, decimal price)
        {
            if(price<0)
            {
                return BadRequest("Цена отрицательная!");
            }
            
            _serviceService.Post(name, durationMinutes, price);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, string name, int durationMinutes, decimal price)
        {
            _serviceService.Put(id,name, durationMinutes, price);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _serviceService.Delete(id);
            return Ok();
        }

    }
}
