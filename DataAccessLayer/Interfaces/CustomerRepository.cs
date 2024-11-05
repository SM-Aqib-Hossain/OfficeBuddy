using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public async Task<IEnumerable<Customer>> GetCustomerAsync()
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



        //public Task<Customer> GetCustomerByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateCustomerAsync(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
