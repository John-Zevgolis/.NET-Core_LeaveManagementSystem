using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Data;
using backend.Models.LeaveTypes;
using backend.Services;

namespace LeaveManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypesController(ILeaveTypesSevice leaveTypesService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetLeaveTypes()
        {
            var leaveTypes = await leaveTypesService.GetAll();

            return Ok(leaveTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveType(int? id)
        {
            if(id == null) return BadRequest(new { message = "Το ID δεν μπορεί να είναι κενό." });

            var leaveType = await leaveTypesService.Get(id);

            if(leaveType == null) return NotFound();

            return Ok(leaveType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaveType(LeaveTypeCreateVM leaveTypeCreate)
        {
            if(!ModelState.IsValid) return ValidationProblem(ModelState);
            
            try
            {
                var leaveType = await leaveTypesService.Create(leaveTypeCreate);

                return CreatedAtAction(nameof(GetLeaveType), new {id = leaveType.Id}, leaveType);
            } catch(InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), ex.Message);
                return ValidationProblem(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveType(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if(id != leaveTypeEdit.Id) return BadRequest(new { message = "Το ID στο URL δεν ταιριάζει με το ID της άδειας." });

            if(!ModelState.IsValid) return ValidationProblem(ModelState);

            try
            {
                var isUpdated = await leaveTypesService.Update(id, leaveTypeEdit);

                if(!isUpdated) return NotFound();

                return NoContent();
            } catch(InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), ex.Message);
                return ValidationProblem(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveType(int id)
        {
            var result = await leaveTypesService.Remove(id);

            if(!result) return NotFound(new { message = $"Η άδεια με ID {id} δεν βρέθηκε" });
    
            return NoContent();
        }
    }
}