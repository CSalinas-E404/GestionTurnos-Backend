using GestionTurnos.Application.Abstraction;
using GestionTurnos.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace GestionTurnos.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public ActionResult Get() {
            var appointments = _appointmentService.GetAll();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var appointment = _appointmentService.GetById(id);
            return Ok(appointment);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AppointmentRequest request)
        {
            var appointment = _appointmentService.CreateAppointment(request);
            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] AppointmentRequest request)
        {
            var appointment = _appointmentService.UpdateAppointment(id, request);
            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _appointmentService.DeleteAppointment(id);
            return NoContent();
        }
    }
}
