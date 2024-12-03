namespace TestWebAppMin.DataAccess.DTO
{
    public record FullNameModel
    {
        public string FirstName { get; init; }
        public string MiddleName { get; init; }
        public string LastName { get; init; }
    }
}
