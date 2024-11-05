
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
        Task<IEnumerable<Customer>> GetCustomerAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        //Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
