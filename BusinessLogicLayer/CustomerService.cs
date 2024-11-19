using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        //

        public async Task<List<Customer>> GetCustomerAsync()
        {
            return (List<Customer>)await _customerRepository.GetCustomerAsync();    
        }



        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }
        


        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<Customer> Authenticate(string Name, string Password)
        {
            return await _customerRepository.Authenticate(Name, Password);
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            await _customerRepository.UpdateCustomerAsync(id, customer);
        }
        public async Task<int?> GetBalanceById(int id)
        {
            return await _customerRepository.GetBalanceById(id);
        }
        public async Task<Customer> UpdateCustomerBalanceByIdAsync(int id, int newBalance)
        {
            return await _customerRepository.UpdateCustomerBalanceByIdAsync(id, newBalance);
        }


    }
}
