using TestWebAppMin.Services.DTO;

namespace TestWebAppMin.Services
{
    public interface ICustomerProvider
    {
        Task<IReadOnlyList<PurchasesPerCategoryDto>> GetCategoriesPurchasesCount(Guid customerId);
        Task<IReadOnlyList<CustomerLastPurchaseDto>> GetCustomerLastPurchases(int daysCount);
        Task<IReadOnlyList<CustomerDto>> GetCustomersByBirthday(DateOnly birthday);
    }
}
