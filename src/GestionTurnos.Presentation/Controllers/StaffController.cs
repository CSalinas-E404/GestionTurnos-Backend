using GestionTurnos.Application.Abstraction;
using GestionTurnos.Application.Exceptions;
using GestionTurnos.Application.Request;
using GestionTurnos.Application.Response;
using GestionTurnos.Domain.Entities;
using GestionTurnos.Presentation.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionTurnos.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        
        [Authorize(Policy = Policies.Admin)]
        [HttpGet("Business/Staffs")]
        public ActionResult<List<StaffsResponse>> GetStaffOfBusiness() 
        {

            try
            {
                var staffs = _staffService.GetStaffOfCurrentBusiness();
                return Ok(staffs);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado y no se pudo obtener la lista de personal.");
            }
        }

        [HttpPost]
        public ActionResult<Staff> CreateStaffWhitBusiness([FromBody] BusinessRequest user)
        {
            var newUser = _staffService.CreateStaffWhitBusiness(user);
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStaff(Guid id)
        {
            _staffService.DeleteStaff(id);
            return NoContent();
        }

        // [Authorize(Policy = "Admin")]
        [HttpPut]
        public ActionResult<Staff> UpdateStaff([FromBody] Staff user)
        {
            var updatedUser = _staffService.UpdateStaff(user);
            return Ok(updatedUser);
        }
    }
}
