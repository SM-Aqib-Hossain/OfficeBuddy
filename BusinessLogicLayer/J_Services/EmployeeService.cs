using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.J_Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        //

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            return await _employeeRepository.GetEmployeeAsync();
        }



        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }



        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<Employee> Authenticate(string Name, string Password)
        {
            return await _employeeRepository.Authenticate(Name, Password);
        }

        public async Task UpdateEmployeeAsync(int id, Employee employee)
        {
            await _employeeRepository.UpdateEmployeeAsync(id, employee);
        }
        public async Task<int?> GetBalanceById(int id)
        {
            return await _employeeRepository.GetBalanceById(id);
        }
        public async Task<Employee> UpdateEmployeeBalanceByIdAsync(int id, int newBalance)
        {
            return await _employeeRepository.UpdateEmployeeBalanceByIdAsync(id, newBalance);
        }


    }
}
