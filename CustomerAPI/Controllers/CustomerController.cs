using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(Name = "Get Customer")]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "Get Customer Id")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);

            if (customer == null) return NotFound();

            return customer;
        }

        [HttpPost(Name = "Create Customer")]
        public ActionResult<Customer> Create(Customer customer)
        {
            _customerService.Create(customer);

            return customer;
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Customer customer)
        {
            var a = _customerService.Get(id);

            if (a == null) return NotFound();

            _customerService.Update(id, customer);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var customer = _customerService.Get(id);

            if (customer == null) return NotFound();

            _customerService.Delete(id);

            return Ok();
        }
    }
}
