﻿using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Dto;
using Microsoft.AspNetCore.Authorization;


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
        [HttpPut("/api/update/Customers/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            

            await _customerService.UpdateCustomerAsync(id, customer);
            return NoContent();
        }

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
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestDto loginRequestDto)
        {
            string Name = loginRequestDto.Name;
            string Password = loginRequestDto.Password;

            var customer = await _customerService.Authenticate(Name, Password);

            if (customer == null)
            {
                // Return a more user-friendly message
                return Unauthorized("Wrong username or password.");
            }

            return Ok(customer);
        }
        [HttpGet("balance/{id}")]
        public async Task<int?> GetBalanceById(int id)
        {
            var balance = await _customerService.GetBalanceById(id);

            // Return null if balance is not found; otherwise, return the balance value.
            return balance;
        }
        [HttpPut("balanceUpdate/{id}")]
        public async Task<IActionResult> UpdateCustomerBalanceById(int id,int newBalance)
        {
            var customer = await _customerService.UpdateCustomerBalanceByIdAsync(id, newBalance);

            if (customer == null)
            {
                return NotFound(new { message = "Customer not found." });
            }

            return Ok(customer);
        }

    }
}
