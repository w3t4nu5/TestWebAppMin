namespace TestWebAppMin.Services.DTO
{
    public record FullNameDto
    {
        public string? FirstName { get; init; }
        public string? MiddleName { get; init; }
        public string? LastName { get; init; }
    }
}
