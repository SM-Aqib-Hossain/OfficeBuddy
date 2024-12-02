using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.J_Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Departments
        [HttpGet("/GetAllDepartmentsAsync")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartmentsAsync()
        {
            return await _departmentService.GetAllDepartmentsAsync();
        }

        // GET: api/Departments/5
        [HttpGet("/GetDepartmentById/{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            return await _departmentService.GetDepartmentById(id);  
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/UpdateDepartment/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department department)
        {
            try
            {
                await _departmentService.UpdateDepartment(id, department);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Department not found." });
            }
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/AddDepartment")]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            var newDept = await _departmentService.AddDepartment(department);
            return newDept;
        }

        // DELETE: api/Departments/5
        [HttpDelete("/DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                await _departmentService.DeleteDepartment(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Dept not found." });
            }
        }

        //private bool DepartmentExists(int id)
        //{
        //    return _context.Departments.Any(e => e.Id == id);
        //}
    }
}
