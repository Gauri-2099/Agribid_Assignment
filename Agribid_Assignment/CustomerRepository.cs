// Data/CustomerRepository.cs

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agribid_Assignment.Models;
using Agribid_Assignment.Data;

namespace Agribid_Assignment
{


    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer Create(Customer customer);
        Customer Update(int id, Customer customer);
        bool Delete(int id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }        
        }

        public Customer GetById(int id)
        {
            try
            {
                return _context.Customers.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }        
        }

        public Customer Create(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  Customer Update(int id, Customer customer)
        {
            try
            {
                var existingCustomer = _context.Customers.Find(id);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = customer.Name;
                    existingCustomer.ContactNo = customer.ContactNo;
                    _context.SaveChanges();
                }
                return existingCustomer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  bool Delete(int id)
        {
            try
            {
                var customerToRemove = _context.Customers.Find(id);
                if (customerToRemove != null)
                {
                    _context.Customers.Remove(customerToRemove);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
