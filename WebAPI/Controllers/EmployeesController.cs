using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Dto;
using Microsoft.AspNetCore.Authorization;
using BusinessLogicLayer.Interfaces;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    //https://]localhost:7011/
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: 
        [HttpGet("/GetEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeeAsync();
            return Ok(employees);
        }

        // GET: api/Employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound(new { message = "employee not found." });
            }

            return Ok(employee);
        }

        //POST: api/Employees
        [HttpPost("/AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var newEmployee = await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployees), new { id = newEmployee.Id }, newEmployee);
        }

        // PUT: 
        [HttpPut("/UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            

            await _employeeService.UpdateEmployeeAsync(id, employee);
            return NoContent();
        }

        // DELETE: api/Employees/{id}
        [HttpDelete("/DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return Ok();
            }
            catch
            {
                return NotFound(new { message = "employee not found." });
            }
        }

        // POST: api/Employees
        [HttpPost("authenticate")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestDto loginRequestDto)
        {
            int Id = loginRequestDto.Id;
            string Password = loginRequestDto.Password;

            var employee = await _employeeService.Authenticate(Id, Password);

            if (employee == null)
            {
                // Return a more user-friendly message
                return Unauthorized("Wrong username or password.");
            }

            return Ok(employee);
        }

        // GET: api/Employees
        [HttpGet("Balance/GetBalanceById/{id}")]
        public async Task<int?> GetBalanceById(int id)
        {
            var balance = await _employeeService.GetBalanceById(id);

            // Return null if balance is not found; otherwise, return the balance value.
            return balance;
        }


        // PUT: api/Employees
        [HttpPut("/Balance/UpdateEmployeeBalanceById/{id}")]
        public async Task<IActionResult> UpdateEmployeeBalanceById(int id,int newBalance)
        {
            var employee = await _employeeService.UpdateEmployeeBalanceByIdAsync(id, newBalance);

            if (employee == null)
            {
                return NotFound(new { message = "employee not found." });
            }

            return Ok(employee);
        }

    }
}
