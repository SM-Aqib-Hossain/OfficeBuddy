using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerService.GetCustomerAsync();
            return Ok(customers);
        }

        // GET: api/Customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound(new { message = "Customer not found." });
            }

            return Ok(customer);
        }

        //POST: api/Customers
       [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            var newCustomer = await _customerService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomers), new { id = newCustomer.Id }, newCustomer);
        }

        // PUT: api/Customers/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return BadRequest("Customer ID mismatch.");
        //    }

        //    await _customerService.UpdateCustomerAsync(customer);
        //    return NoContent();
        //}

        // DELETE: api/Customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return Ok();
            }
            catch
            {
                return NotFound(new { message = "Customer not found." });
            }
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequestDto loginRequestDto)
        {
            string Name = loginRequestDto.Name;
            string Password = loginRequestDto.Password;
            var Customer = _customerService.Authenticate(Name, Password);
            if (Customer is null)
            {
                return NotFound("Invalid email or password");
            }

            // Instead of returning the full employee entity, you could return a safer response
            // For example, create a response DTO that does not include sensitive information
            //var employeeDto = new EmployeeResponseDto
            //{
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    Email = employee.Email,
            //    // Add any other non-sensitive fields as needed
            //};

            return Ok(Customer);
        }
    }
}
