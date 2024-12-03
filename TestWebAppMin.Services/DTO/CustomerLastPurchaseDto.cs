namespace TestWebAppMin.Services.DTO
{
    public record CustomerLastPurchaseDto
    {
        public required CustomerDto Customer { get; init; }
        public DateTime PurchaseDate { get; init; }
    }
}
