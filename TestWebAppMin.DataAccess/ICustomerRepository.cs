using System.Linq.Expressions;
using TestWebAppMin.DataAccess.DTO;
using TestWebAppMin.DataAccess.Entities;

namespace TestWebAppMin.DataAccess
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<TCustomer>> GetCustomerByCriteria<TCustomer>(Expression<Func<Customer, TCustomer>> selector, Expression<Func<Customer, bool>> filter);
        Task<IReadOnlyList<CustomerLastPurchaseModel>> GetCustomersWithPurchasesByDaysCount(int daysCount);
        Task<List<PurchasesPerCategoryModel>> GetPurchasedCategories(Guid customerId);
    }
}
