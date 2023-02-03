using Microsoft.AspNetCore.Mvc;
using RESTServer.Models;
using RESTServer.Repo;
using System.Collections.Generic;
using System.Linq;

namespace RESTServer.Controllers
{
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerRepo _customerRepo;
        public CustomerController(ICustomerRepo customerRepo) { 
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerRepo.GetCustomers();
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<Customer> customers)
        {
            if (customers == null)
            {
                return BadRequest();
            }

            if (customers.Count() < 2)
            {
                return BadRequest("Request should contain at least 2 different customers");
            }

            var result = _customerRepo.Add(customers);
            return Ok(result);
        }
    }
}
