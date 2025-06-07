using CoolZoneAPI.Domain.Enum;

namespace CoolZoneAPI.Application.DTOs
{
    public class ThermalShelterResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ShelterType Type { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Capacity { get; set; }
     
        public OpeningHours OpeningHours { get; set; }

        public Guid CityId { get; set; }
        public CityResponseDto City { get; set; } = new();
    }
}
