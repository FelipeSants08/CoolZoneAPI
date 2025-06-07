using Microsoft.AspNetCore.Mvc;
using System.Net;
using CoolZoneAPI.Domain.Entity;
using CoolZoneAPI.Persistence.Repositories;
using AutoMapper;
using CoolZoneAPI.Application.DTOs;

namespace CoolZoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("CRUD Cities")]
    public class CitiesController : ControllerBase
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IMapper _mapper;

        public CitiesController(IRepository<City> cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IEnumerable<CityResponseDto>> GetCities()
        {
            var cities = await _cityRepository.GetAsync();
            return _mapper.Map<IEnumerable<CityResponseDto>>(cities);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CityResponseDto>> GetCity(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return _mapper.Map<CityResponseDto>(city);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CityResponseDto>> PostCity([FromBody] CreateCityDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cityEntity = _mapper.Map<City>(createDto);

            await _cityRepository.AddAsync(cityEntity);

            var cityResponse = _mapper.Map<CityResponseDto>(cityEntity);

            return CreatedAtAction(nameof(GetCity), new { id = cityResponse.Id }, cityResponse);
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutCity(Guid id, [FromBody] UpdateCityDto updateDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var existingCity = await _cityRepository.GetByIdAsync(id);
            if (existingCity == null)
            {
                return NotFound($"Cidade com ID {id} não encontrada para atualização.");
            }
            _mapper.Map(updateDto, existingCity);

            await _cityRepository.UpdateAsync(existingCity);

            var updatedCityResponse = _mapper.Map<CityResponseDto>(existingCity);
            return Ok(updatedCityResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            await _cityRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
