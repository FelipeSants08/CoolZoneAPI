using CoolZoneAPI.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace CoolZoneAPI.Application.DTOs
{
    public class CreateThermalShelterDto
    {
        [Required(ErrorMessage = "O nome do abrigo é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome não pode exceder 200 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de abrigo é obrigatório.")]
        public ShelterType Type { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [MaxLength(300, ErrorMessage = "O endereço não pode exceder 300 caracteres.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "A capacidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade deve ser um valor positivo.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "O horário de funcionamento é obrigatório.")]
        
        public OpeningHours OpeningHours { get; set; }

        [Required(ErrorMessage = "O ID da cidade é obrigatório.")]
        public Guid CityId { get; set; }
    }
}
