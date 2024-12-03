namespace TestWebAppMin.Services.DTO
{
    public record CustomerDto
    {
        public required Guid Id { get; init; }

        public required FullNameDto FullName { get; init; }
    }
}
