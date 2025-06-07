using AutoMapper;
using CoolZoneAPI.Application.DTOs;
using CoolZoneAPI.Domain.Entity;

namespace CoolZoneAPI.Infraestructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamentos para City
            CreateMap<CreateCityDto, City>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.ThermalShelters, opt => opt.Ignore()); 

            CreateMap<UpdateCityDto, City>(); 
            CreateMap<City, CityResponseDto>();

            // Mapeamentos para ThermalShelter
            CreateMap<CreateThermalShelterDto, ThermalShelter>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id será gerado pelo BD
                .ForMember(dest => dest.City, opt => opt.Ignore()); // Objeto City é um relacionamento, não mapeado diretamente do DTO de criação

            CreateMap<UpdateThermalShelterDto, ThermalShelter>(); // Id é passado para atualização

            
            CreateMap<ThermalShelter, ThermalShelterResponseDto>();

       
        }
    }
}
