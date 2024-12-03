using System.ComponentModel.DataAnnotations;

namespace TestWebAppMin.Services.DTO
{
    public record BirthdayDto
    {
        [Required]
        public required int Day { get; init; }

        [Required]
        public required int Month { get; init; }
    }
}
