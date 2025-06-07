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
    [Tags("CRUD Thermal Shelters")]
    public class ThermalSheltersController : ControllerBase
    {
       
        private readonly IThermalShelterRepository _shelterRepository;
        private readonly IMapper _mapper;

        public ThermalSheltersController(IThermalShelterRepository shelterRepository, IMapper mapper)
        {
            _shelterRepository = shelterRepository;
            _mapper = mapper;
        }

 
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IEnumerable<ThermalShelterResponseDto>> GetThermalShelters()
        {
        
            var shelters = await _shelterRepository.GetAllWithCityAsync();

            return _mapper.Map<IEnumerable<ThermalShelterResponseDto>>(shelters);
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ThermalShelterResponseDto>> GetThermalShelter(Guid id)
        {
            
            var shelter = await _shelterRepository.GetByIdWithCityAsync(id);

            if (shelter == null)
            {
                return NotFound();
            }

            return _mapper.Map<ThermalShelterResponseDto>(shelter);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ThermalShelterResponseDto>> PostThermalShelter([FromBody] CreateThermalShelterDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shelterEntity = _mapper.Map<ThermalShelter>(createDto);

           
            await _shelterRepository.AddAsync(shelterEntity);

            
            var createdShelterWithCity = await _shelterRepository.GetByIdWithCityAsync(shelterEntity.Id);

            
            if (createdShelterWithCity == null)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao recuperar o abrigo térmico recém-criado.");
            }

            var shelterResponse = _mapper.Map<ThermalShelterResponseDto>(createdShelterWithCity);

            return CreatedAtAction(nameof(GetThermalShelter), new { id = shelterResponse.Id }, shelterResponse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutThermalShelter(Guid id, [FromBody] UpdateThermalShelterDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            var existingShelter = await _shelterRepository.GetByIdWithCityAsync(id);
            if (existingShelter == null)
            {
                return NotFound($"Abrigo térmico com ID {id} não encontrado para atualização.");
            }

            _mapper.Map(updateDto, existingShelter);

            await _shelterRepository.UpdateAsync(existingShelter);

            
            var updatedShelterResponse = _mapper.Map<ThermalShelterResponseDto>(existingShelter);
            return Ok(updatedShelterResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteThermalShelter(Guid id)
        {
            var shelter = await _shelterRepository.GetByIdAsync(id); 
            if (shelter == null)
            {
                return NotFound();
            }

            await _shelterRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
