
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee emmployee);
        Task UpdateEmployeeAsync(int id, Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<Employee> Authenticate(string Name, string Password);
        Task<int?> GetBalanceById(int id);
        Task<Employee> UpdateEmployeeBalanceByIdAsync(int id, int newBalance);
    }
}
