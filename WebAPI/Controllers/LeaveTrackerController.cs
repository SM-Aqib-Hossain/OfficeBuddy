using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTrackerController : ControllerBase
    {
        private readonly ILeaveTrackerService _leaveTrackerService;

        public LeaveTrackerController(ILeaveTrackerService leaveTrackerService)
        {
            _leaveTrackerService = leaveTrackerService;
        }

        // GET: api/LeaveTracker
        [HttpGet("GetAllLeaves")]
        public async Task<ActionResult<IEnumerable<LeaveTracker>>> GetAllLeaves()
        {
            var leaves = await _leaveTrackerService.GetAllLeaves();
            return Ok(leaves);
        }

        // GET: api/LeaveTracker/{id}
        [HttpGet("GetLeaveById/{id}")]
        public async Task<ActionResult<LeaveTracker>> GetLeaveById(int id)
        {
            try
            {
                var leave = await _leaveTrackerService.GetLeaveById(id);
                return Ok(leave);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Leave record not found." });
            }
        }

        // GET: api/LeaveTracker/employee/{employeeId}
        [HttpGet("GetLeavesByEmployeeId/{employeeId}")]
        public async Task<ActionResult<IEnumerable<LeaveTracker>>> GetLeavesByEmployeeId(int employeeId)
        {
            var leaves = await _leaveTrackerService.GetLeavesByEmployeeId(employeeId);

            if (leaves == null || !leaves.Any())
            {
                return NotFound(new { message = "No leave records found for this employee." });
            }

            return Ok(leaves);
        }

        // GET: api/LeaveTracker/dates
        [HttpGet("GetLeavesByDateRange/dates")]
        public async Task<ActionResult<IEnumerable<LeaveTracker>>> GetLeavesByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var leaves = await _leaveTrackerService.GetLeavesByDateRange(startDate, endDate);

            if (leaves == null || !leaves.Any())
            {
                return NotFound(new { message = "No leave records found in the specified date range." });
            }

            return Ok(leaves);
        }

        // POST: api/LeaveTracker
        [HttpPost("AddLeave")]
        public async Task<ActionResult<LeaveTracker>> AddLeave(LeaveTracker leaveTracker)
        {
            var newLeave = await _leaveTrackerService.AddLeave(leaveTracker);
            return CreatedAtAction(nameof(GetLeaveById), new { id = newLeave.Id }, newLeave);
        }

        // PUT: api/LeaveTracker/{id}
        [HttpPut("UpdateLeave/{id}")]
        public async Task<IActionResult> UpdateLeave(int id, LeaveTracker leaveTracker)
        {
            try
            {
                var updatedLeave = await _leaveTrackerService.UpdateLeave(id, leaveTracker);
                return Ok(updatedLeave);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Leave record not found." });
            }
        }

        // DELETE: api/LeaveTracker/{id}
        [HttpDelete("DeleteLeave/{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            try
            {
                await _leaveTrackerService.DeleteLeave(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Leave record not found." });
            }
        }

        // GET: api/LeaveTracker/status/{status}
        [HttpGet("GetLeavesByStatus/{status}")]
        public async Task<ActionResult<IEnumerable<LeaveTracker>>> GetLeavesByStatus(string status)
        {
            var leaves = await _leaveTrackerService.GetPendingLeaves();

            if (leaves == null || !leaves.Any())
            {
                return NotFound(new { message = $"No leave records found with status: {status}." });
            }

            return Ok(leaves);
        }

        // GET: api/LeaveTracker/type/{type}
        [HttpGet("GetLeavesByType/{type}")]
        public async Task<ActionResult<IEnumerable<LeaveTracker>>> GetLeavesByType(string type)
        {
            var leaves = type.ToLower() switch
            {
                "sick" => await _leaveTrackerService.GetSickLeaves(),
                "casual" => await _leaveTrackerService.GetCasualLeaves(),
                _ => null
            };

            if (leaves == null || !leaves.Any())
            {
                return NotFound(new { message = $"No leave records found with type: {type}." });
            }

            return Ok(leaves);
        }
        [HttpPost("ToggleStatus/{id}/{status}")]
        public async Task<IActionResult> ToggleStatus(int id, string status, DateTime datetime)
        {
            try
            {
                var leave = await _leaveTrackerService.ToggleStatus(id, status, datetime);
                if (leave == null)
                {
                    return NotFound(new { message = $"No leave record found for ID {id}." });
                }

                return Ok(leave);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while toggling status.", details = ex.Message });
            }
        }
    }
}
