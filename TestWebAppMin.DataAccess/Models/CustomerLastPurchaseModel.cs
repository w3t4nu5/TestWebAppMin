namespace TestWebAppMin.DataAccess.DTO
{
    public record CustomerLastPurchaseModel
    {
        public required CustomerModel Customer { get; init; }
        public DateTime PurchaseDate { get; init; }
    }
}
