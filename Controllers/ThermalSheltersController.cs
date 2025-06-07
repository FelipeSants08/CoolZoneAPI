using Microsoft.AspNetCore.Mvc;
using System.Net;
using CoolZoneAPI.Domain.Entity;
using CoolZoneAPI.Persistence.Repositories;

namespace CoolZoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("CRUD Thermal Shelters")]
    public class ThermalSheltersController : ControllerBase
    {
        private readonly IRepository<ThermalShelter> _shelterRepository;

        public ThermalSheltersController(IRepository<ThermalShelter> shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IEnumerable<ThermalShelter>> GetThermalShelters()
        {
            return await _shelterRepository.GetAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ThermalShelter>> GetThermalShelter(Guid id)
        {
            var shelter = await _shelterRepository.GetByIdAsync(id);

            if (shelter == null)
            {
                return NotFound();
            }

            return shelter;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<ThermalShelter>> PostThermalShelter(ThermalShelter shelter)
        {
            await _shelterRepository.AddAsync(shelter);
            return CreatedAtAction("GetThermalShelter", new { id = shelter.Id }, shelter);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutThermalShelter(Guid id, ThermalShelter shelter)
        {
            if (id != shelter.Id)
                return BadRequest();

            await _shelterRepository.UpdateAsync(shelter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteThermalShelter(Guid id)
        {
            var shelter = await _shelterRepository.GetByIdAsync(id);
            if (shelter == null)
                return NotFound();

            await _shelterRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
