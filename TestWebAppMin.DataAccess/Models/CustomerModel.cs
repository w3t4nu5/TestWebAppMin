namespace TestWebAppMin.DataAccess.DTO
{
    public record CustomerModel
    {
        public required Guid Id { get; init; }

        public required FullNameModel FullName { get; init; }
    }
}
