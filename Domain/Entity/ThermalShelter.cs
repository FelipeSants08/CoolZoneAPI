using CoolZoneAPI.Domain.Enum;

namespace CoolZoneAPI.Domain.Entity
{
    public class ThermalShelter
    {

        public Guid Id { get; set; }

        public string? Name { get; set; }
        
        public ShelterType Type { get; set; }
        public string? Address { get; set; } = null;
        public int Capacity { get; set; } 
        public OpeningHours OpeningHours { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; } = null!;

    }
}
