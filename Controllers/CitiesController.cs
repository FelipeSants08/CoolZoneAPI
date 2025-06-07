using Microsoft.AspNetCore.Mvc;
using System.Net;
using CoolZoneAPI.Domain.Entity;
using CoolZoneAPI.Persistence.Repositories;

namespace CoolZoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("CRUD Cities")]
    public class CitiesController : ControllerBase
    {
        private readonly IRepository<City> _cityRepository;

        public CitiesController(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IEnumerable<City>> GetCities()
        {
            return await _cityRepository.GetAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<City>> GetCity(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            await _cityRepository.AddAsync(city);
            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutCity(Guid id, City city)
        {
            if (id != city.Id)
                return BadRequest();

            await _cityRepository.UpdateAsync(city);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city == null)
                return NotFound();

            await _cityRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
