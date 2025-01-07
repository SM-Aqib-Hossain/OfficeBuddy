using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.J_Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Employee>> GetEmployeeAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            employee.Password = PasswordHasher.HashPassword(employee.Password);
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Cutomer Not found ");
            }
        }



        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee != null)
            {
                return employee;
            }
            else
            {
                throw new KeyNotFoundException("Cutomer Not found ");
            }
        }

        public async Task<Employee?> Authenticate(int Id, string Password)
        {
            // Simulating authentication by checking the database for matching credentials
            var employee = await _dbContext.Employees.FindAsync(Id);
            if (employee != null && PasswordHasher.VerifyPassword(Password, employee.Password))
            {
                return employee;
            }
            throw new UnauthorizedAccessException("Invalid credentials");
        }
        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var employeeToUpdate = await _dbContext.Employees.FindAsync(id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = employee.Name;
                employeeToUpdate.City = employee.City;
                employeeToUpdate.Password = PasswordHasher.HashPassword(employee.Password);
                employeeToUpdate.Role = employee.Role;
                employeeToUpdate.Balance = employee.Balance;

                await _dbContext.SaveChangesAsync();
                return employeeToUpdate;
            }
            throw new KeyNotFoundException("Employee not found.");
        }
        public async Task<int?> GetBalanceById(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                return employee.Balance;
            }
            else
            {
                throw new KeyNotFoundException("Customer not found.");
            }
        }
        public async Task<Employee> UpdateEmployeeBalanceByIdAsync(int id, int newBalance)
        {
            var employeeToUpdate = await _dbContext.Employees.FindAsync(id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Balance = newBalance;
                await _dbContext.SaveChangesAsync();
                return employeeToUpdate;
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
