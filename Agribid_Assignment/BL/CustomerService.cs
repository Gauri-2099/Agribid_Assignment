// BusinessLogic/CustomerService.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using Agribid_Assignment.Models;
//using Agribid_Assignment.Data;
//using Agribid_Assignment.Models;

namespace Agribid_Assignment.BL
{


    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(int id, Customer customer);
        bool DeleteCustomer(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public  Customer CreateCustomer(Customer customer)
        {
            return  _customerRepository.Create(customer);
        }

        public  Customer UpdateCustomer(int id, Customer customer)
        {
            return  _customerRepository.Update(id, customer);
        }

        public  bool DeleteCustomer(int id)
        {
            return  _customerRepository.Delete(id);
        }
    }

}
