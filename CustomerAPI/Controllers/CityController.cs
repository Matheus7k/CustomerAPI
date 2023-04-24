using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet(Name = "Get Cities")]
        public ActionResult<List<City>> Get() => _cityService.Get();

        [HttpGet("{id:length(24)}", Name = "Get City Id")]
        public ActionResult<City> Get(string id)
        {
            var city = _cityService.Get(id);

            if (city == null) return NotFound();

            return city;
        }

        [HttpPost(Name = "Create City")]
        public ActionResult<City> Create(City city)
        {
            _cityService.Create(city);

            return CreatedAtRoute("Get City Id", new { id = city.Id }, city);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, City city)
        {
            var c = _cityService.Get(id);

            if (c == null) return NotFound();

            _cityService.Update(id, city);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var city = _cityService.Get(id);

            if (city == null) return NotFound();

            _cityService.Delete(id);

            return Ok();
        }
    }
}
