using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext; 
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Customer>> GetCustomerAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Cutomer Not found ");
            }
        }



        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer =  await _dbContext.Customers.FindAsync(id);

            if (customer != null)
            {
                return customer;
            }
            else
            {
                throw new KeyNotFoundException("Cutomer Not found ");
            }
        }

        public async Task<Customer?> Authenticate(string Name, string Password)
        {
            // Simulating authentication by checking the database for matching credentials
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Name == Name && c.Password == Password);

            // Return null if authentication fails
            return customer;
        }
        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            var customerToUpdate = await _dbContext.Customers.FindAsync(id);
            if (customerToUpdate != null)
            {
                customerToUpdate.Name = customer.Name;
                customerToUpdate.City = customer.City;
                customerToUpdate.Password = customer.Password;
                customerToUpdate.Role = customer.Role;
                customerToUpdate.Balance = customer.Balance;

                await _dbContext.SaveChangesAsync();
                return customerToUpdate; // Return the updated customer
            }
            throw new KeyNotFoundException("Customer not found.");
        }
        public async Task<int?> GetBalanceById(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                return customer.Balance;
            }
            else
            {
                throw new KeyNotFoundException("Customer not found.");
            }
        }
        public async Task<Customer> UpdateCustomerBalanceByIdAsync(int id, int newBalance)
        {
            var customerToUpdate = await _dbContext.Customers.FindAsync(id);
            if (customerToUpdate != null)
            {
                customerToUpdate.Balance = newBalance;
                await _dbContext.SaveChangesAsync();
                return customerToUpdate; 
            }
            throw new KeyNotFoundException("Customer not found.");
        }
        //public async Task<Customer> Authenticate(string Name, string Password)
        //{
        //    // Simulating authentication by checking the database for matching credentials
        //    var customer = await _dbContext.Customers
        //        .FirstOrDefaultAsync(c => c.Name == Name && c.Password == Password);

        //    if (customer != null)
        //    {
        //        return customer;
        //    }
        //    else
        //    {
        //        throw new UnauthorizedAccessException("Invalid credentials");
        //    }
        //}



    }
}
