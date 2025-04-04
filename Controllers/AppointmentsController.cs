using AspVetMedForEnimals.Interfaces;
using AspVetMedForEnimals.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspVetMedForEnimals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        IAppointment _appointmentService;
        public AppointmentsController(IAppointment appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public List<Appointment> GetAll()
        {
            return _appointmentService.GetAll();
        }
        [HttpGet("{id}")]
        public Appointment Get(int id)
        {
            return _appointmentService.Get(id);
        }

        [HttpPost]
        public IActionResult Post(int petId, int serviceId, DateTime dateTime, string notes)
        {
            _appointmentService.Post(petId, serviceId, dateTime, notes);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, int petId, int serviceId, DateTime dateTime, string notes)
        {
            _appointmentService.Put(id, petId, serviceId, dateTime, notes);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _appointmentService.Delete(id);
            return Ok();
        }
    }
}
