namespace TestWebAppMin.Services.DTO
{
    public record PurchasesPerCategoryDto
    {
        public required string CategoryName { get; init; }
        public int PurchasesCount { get; init; }
    }
}
