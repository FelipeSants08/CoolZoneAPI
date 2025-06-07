namespace CoolZoneAPI.Domain.Entity
{
    public class City
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }

        public List<ThermalShelter> ThermalShelters { get; set; } = new();
    }
}
