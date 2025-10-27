using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public record UpdateHospitalDto
    {
        public Guid Id { get; init; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Type { get; set; }
    }
}



