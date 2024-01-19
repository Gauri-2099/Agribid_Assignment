using Agribid_Assignment.BL;
using Agribid_Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// Controllers/CustomerController.cs

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Agribid_Assignment.BusinessLogic;
//using Agribid_Assignment.Models;

namespace Agribid_Assignment.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var customers = _customerService.GetAllCustomers();
            if (customers==null)
            {
                return NotFound("Could not fetch customer details!");
            }
            return Ok(customers);
        }

        // GET api/customer/1
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound("Could not find customer details for Id =>"+id);
            }
            return Ok(customer);
        }

        // POST api/customer
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            var createdCustomer =  _customerService.CreateCustomer(customer);
            if (createdCustomer==null)
            {
                return BadRequest("Could not save customer details!");
            }
            return CreatedAtAction(nameof(Get), new { id = createdCustomer.Id }, createdCustomer);
        }

        // PUT api/customer/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            var updatedCustomer =  _customerService.UpdateCustomer(id, customer);
            if (updatedCustomer == null)
            {
                return NotFound("Could not update customer details!");
            }
            return NoContent();
        }

        // DELETE api/customer/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result =  _customerService.DeleteCustomer(id);
            if (!result)
            {
                return NotFound("Could not delete customer!");
            }
            return NoContent();
        }
    }

}
