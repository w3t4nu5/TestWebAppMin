using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestWebAppMin.DataAccess.DTO;
using TestWebAppMin.DataAccess.Entities;

namespace TestWebAppMin.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<IReadOnlyList<TCustomer>> GetCustomerByCriteria<TCustomer>(
            Expression<Func<Customer, TCustomer>> selector,
            Expression<Func<Customer, bool>> filter)
        {
            List<TCustomer> customers;

            using var context = new CustomersDbContext();
            customers = await context.Customers.AsNoTracking().Where(filter).Select(selector).ToListAsync();

            return customers;
        }

        public async Task<IReadOnlyList<CustomerLastPurchaseModel>> 
            GetCustomersWithPurchasesByDaysCount(int daysCount)
        {
            using var context = new CustomersDbContext();

            //must be refactored
            List<CustomerLastPurchaseModel> result = await context.Customers.AsNoTracking()
                    .Where(c => c.Purchases.Any(p => p.PurchaseDate >= DateTime.Now.AddDays(-daysCount)))
                    .Select(c => new CustomerLastPurchaseModel
                    {
                        Customer = new CustomerModel {
                            Id = c.Id,
                            FullName =
                            new FullNameModel
                            {
                                FirstName = c.FirstName,
                                MiddleName = c.MiddleName,
                                LastName = c.LastName }
                        },
                        PurchaseDate = c.Purchases
                            .Where(p => p.PurchaseDate >= DateTime.Now.AddDays(-daysCount))
                            .Max(p => p.PurchaseDate)
                    })
                    .ToListAsync();


            return result;
        }

        public async Task<List<PurchasesPerCategoryModel>> GetPurchasedCategories(Guid customerId)
        {
            using var context = new CustomersDbContext();

            var result = await context.Categories.AsNoTracking()
                .Include(c => c.Purchases)
                .Select(c => new PurchasesPerCategoryModel
                {
                    CategoryName = c.Name,
                    PurchasesCount = c.Purchases.Count()
                })
                .ToListAsync();

            return result;
        }
    }
}
