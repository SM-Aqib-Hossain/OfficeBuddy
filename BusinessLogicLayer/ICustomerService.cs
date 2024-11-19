
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(int id, Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<Customer> Authenticate(string Name, string Password);
        Task<int?> GetBalanceById(int id);
        Task<Customer> UpdateCustomerBalanceByIdAsync(int id, int newBalance);
    }
}
