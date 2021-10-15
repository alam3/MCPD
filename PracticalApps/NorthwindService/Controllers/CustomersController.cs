// WebAPI Controller class to work with customers

using Microsoft.AspNetCore.Mvc;
using Packt.Shared;
using NorthwindService.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Controllers {
    // base address: api/customers
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase {
        private ICustomerRepository repo;

        // constructor injects repository registered in Startup
        public CustomersController(ICustomerRepository repo) {
            this.repo = repo;
        }

        // GET: api/customers
        // GET: api/customers/?country=[country]
        // this will always return a list of customers even if its empty
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IEnumerable<Customer>> GetCustomers(string country) {
            if (string.IsNullOrWhiteSpace(country)) {
                return await repo.RetrieveAllAsync();
            } else {
                return (await repo.RetrieveAllAsync())
                    .Where(customer => customer.Country == country);
            }
        }

        // GET: api/customers/[id]
        [HttpGet("{id}", Name = nameof(GetCustomer))] // named route
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(string id) {
            Customer c = await repo.RetrieveAsync(id);
            if (c == null) {
                return NotFound(); // 404 Resource not found
            }
            return Ok(c); // 200 OK with customer in body
        }

        // POST: api/customers
        // BODY: Customer (JSON, XML)
        [HttpPost]
        
    }
}