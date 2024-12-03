using System.ComponentModel.DataAnnotations;

namespace TestWebAppMin.DataAccess.DTO
{
    public record BirthdayModel
    {
        [Required]
        public required int Day { get; init; }

        [Required]
        public required int Month { get; init; }
    }
}
