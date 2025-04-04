using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspVetMedForEnimals.Models;
using AspVetMedForEnimals.Services;
using AspVetMedForEnimals.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
namespace AspVetMedForEnimals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {

        IPetsService _petsService;
        public PetsController(IPetsService petsService) 
        {
            _petsService = petsService;
        }
        [HttpGet]
        public List<Pet> GetAll() 
        {
            return _petsService.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_petsService.Get(id) == null)
            {
                return NotFound();
            }
            return Ok(_petsService.Get(id));
        }
        
        [HttpPost]
        public IActionResult Post(string name, string species,string breed,int age,string ownerName )
        {
            if (isValueMinus(age)) 
            {
                return BadRequest("Возраст отрицательный");
                
            }
            else if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Имя питомца пустое.");
               
            }
            else
            {
                _petsService.Post(name, species, breed, age, ownerName);
                return Ok();
            }
           
        }
       
        bool isValueMinus(int value) 
        {
            if(value < 0) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, string name, string species, string breed, int age, string ownerName)
        {
            _petsService.Put(id,name, species, breed, age, ownerName);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _petsService.Delete(id);
            return Ok();
        }




    }
}
