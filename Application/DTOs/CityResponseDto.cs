namespace CoolZoneAPI.Application.DTOs
{
    public class CityResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }
}
