using ApplicationCore.Service.Service_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;

namespace ApplicationCore.Service
{
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer> _CustomerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _CustomerRepository = customerRepository;
        }
        public Customer GetCustomer(string customerID)
        {
            return _CustomerRepository.Read(customerID);
        }
    }
}
