using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Dto;
using Microsoft.AspNetCore.Authorization;
using BusinessLogicLayer.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendancesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: api/Attendances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        // GET: api/Attendances/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendance(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);

            if (attendance == null)
            {
                return NotFound(new { message = "Attendance not found." });
            }

            return Ok(attendance);
        }

        // GET: api/Attendances/employee/{employeeId}
        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendancesByEmployeeId(int employeeId)
        {
            var attendances = await _attendanceService.GetAttendancesByEmployeeIdAsync(employeeId);

            if (attendances == null || !attendances.Any())
            {
                return NotFound(new { message = "No attendance records found for this employee." });
            }

            return Ok(attendances);
        }

        // POST: api/Attendances
        [HttpPost("/api/Attendance/CreateNewAttendance")]
        public async Task<ActionResult<Attendance>> AddAttendance(Attendance attendance)
        {
            var newAttendance = await _attendanceService.AddAttendanceAsync(attendance);
            return CreatedAtAction(nameof(GetAttendance), new { id = newAttendance.Id }, newAttendance);
        }

        // PUT: api/Attendances/{id}
        [HttpPut("/api/Attendance/UpdateAttendance/{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, Attendance attendance)
        {
            try
            {
                await _attendanceService.UpdateAttendanceAsync(id, attendance);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Attendance not found." });
            }
        }

        // DELETE: api/Attendances/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            try
            {
                await _attendanceService.DeleteAttendanceAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Attendance not found." });
            }
        }

        // GET: api/Attendances/status/{status}
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendancesByStatus(string status)
        {
            var attendances = await _attendanceService.GetAttendancesByStatusAsync(status);

            if (attendances == null || !attendances.Any())
            {
                return NotFound(new { message = $"No attendance records found with status: {status}" });
            }

            return Ok(attendances);
        }


    }
}
