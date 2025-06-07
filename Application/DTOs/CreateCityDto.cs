using System.ComponentModel.DataAnnotations;

namespace CoolZoneAPI.Application.DTOs
{
    public class CreateCityDto
    {
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve ter 2 caracteres (Ex: SP).")]
        public string State { get; set; } = string.Empty;
    }
}
