using TestWebAppMin.DataAccess;
using TestWebAppMin.Services.DTO;

namespace TestWebAppMin.Services
{
    public class CustomerProvider(ICustomerRepository _customerRepository) : ICustomerProvider
    {

        public async Task<IReadOnlyList<PurchasesPerCategoryDto>> GetCategoriesPurchasesCount(Guid customerId)
        {
            var result = (await _customerRepository.GetPurchasedCategories(customerId))
                .Select(m => new PurchasesPerCategoryDto { CategoryName = m.CategoryName, PurchasesCount = m.PurchasesCount }).ToList();

            return result;
        }

        public async Task<IReadOnlyList<CustomerLastPurchaseDto>> GetCustomerLastPurchases(int daysCount)
        {
            var result = (await _customerRepository.GetCustomersWithPurchasesByDaysCount(daysCount)).Select(
                m => new CustomerLastPurchaseDto
                {
                    Customer = new CustomerDto
                    {
                        Id = m.Customer.Id,
                        FullName = new FullNameDto { FirstName = m.Customer.FullName.FirstName, MiddleName = m.Customer.FullName.MiddleName, LastName = m.Customer.FullName.LastName }
                    },
                    PurchaseDate = m.PurchaseDate
                }).ToList();

            return result;
        }

        public async Task<IReadOnlyList<CustomerDto>> GetCustomersByBirthday(BirthdayDto birthday)
        {
            int month = birthday.Month;
            int day = birthday.Day;

            var customers = await _customerRepository.GetCustomerByCriteria(
                c => new CustomerDto
                {
                    Id = c.Id,
                    FullName = new FullNameDto
                    {
                        FirstName = c.FirstName,
                        MiddleName = c.MiddleName,
                        LastName = c.LastName,
                    }
                },
                c => c.BirthDate.Month.Equals(month) && c.BirthDate.Day.Equals(day)
            );

            return customers;
        }
    }
}
