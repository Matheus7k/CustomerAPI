using System.Net;
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
        private readonly AddressService _addressService;
        private readonly CityService _cityService;

        public CustomerController(CustomerService customerService, AddressService addressService, CityService cityService)
        {
            _customerService = customerService;
            _addressService = addressService;
            _cityService = cityService;
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
            if(customer.Address.Id != "")
            {
                var address = _addressService.Get(customer.Address.Id);

                customer.Address = address;

                _customerService.Create(customer);

                return CreatedAtRoute("Get Customer Id", new { id = customer.Id }, customer);
            }
            else
            {
                if (customer.Address.City.Id != "")
                {
                    var city = _cityService.Get(customer.Address.City.Id);

                    customer.Address.City = city;

                    var newAddress = _addressService.Create(customer.Address);

                    customer.Address = newAddress;

                    _customerService.Create(customer);

                    return CreatedAtRoute("Get Customer Id", new { id = customer.Id }, customer);
                }
                else
                {             
                    var newCity = _cityService.Create(customer.Address.City);

                    customer.Address.City = newCity;

                    var newAddress = _addressService.Create(customer.Address);

                    customer.Address = newAddress;

                    _customerService.Create(customer);

                    return CreatedAtRoute("Get Customer Id", new { id = customer.Id }, customer);
                }
            }
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
