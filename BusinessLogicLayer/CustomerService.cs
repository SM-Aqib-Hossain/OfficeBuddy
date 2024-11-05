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

        public async Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            return await _customerRepository.GetCustomerAsync();    
        }



        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }
        


        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //public Task UpdateCustomerAsync(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
