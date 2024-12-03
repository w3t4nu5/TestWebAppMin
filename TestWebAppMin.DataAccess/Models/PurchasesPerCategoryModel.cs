namespace TestWebAppMin.DataAccess.DTO
{
    public record PurchasesPerCategoryModel
    {
        public required string CategoryName { get; init; }
        public int PurchasesCount { get; init; }
    }
}
