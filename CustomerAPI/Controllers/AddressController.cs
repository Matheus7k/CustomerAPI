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

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
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
            _addressService.Create(address);

            return address;
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
