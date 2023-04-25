using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;

        public AddressController(AddressService addressService, CityService cityService)
        {
            _addressService = addressService;
            _cityService = cityService;

        }

        [HttpGet(Name = "Get Adresses")]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "Get Address Id")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);

            if (address == null) return NotFound();

            return address;
        }

        [HttpPost(Name = "Create Address")]
        public ActionResult<Address> Create(Address address)
        {
            if(address.City.Id != "")
            {
                var city = _cityService.Get(address.City.Id);

                address.City = city;

                _addressService.Create(address);

                return CreatedAtRoute("Get Address Id", new { id = address.Id }, address);
            }
            else
            {
                var newCity = _cityService.Create(address.City);

                address.City = newCity;

                _addressService.Create(address);

                return CreatedAtRoute("Get Address Id", new { id = address.Id }, address);
            }
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Address address)
        {
            var a = _addressService.Get(id);

            if (a == null) return NotFound();

            _addressService.Update(id, address);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var address = _addressService.Get(id);

            if (address == null) return NotFound();

            _addressService.Delete(id);

            return Ok();
        }
    }
}
