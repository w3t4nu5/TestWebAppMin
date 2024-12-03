using TestWebAppMin.Services.DTO;

namespace TestWebAppMin.Services
{
    public class MockCustomerProvider : ICustomerProvider
    {
        public Task<IReadOnlyList<CustomerDto>> GetCustomersByBirthday(DateOnly birthday)
        {
            IReadOnlyList<CustomerDto> customers =
            [
                new()
                {
                    Id = Guid.NewGuid(),
                    FullName = new FullNameDto { FirstName = "John", LastName = "Doe" }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    FullName = new FullNameDto { FirstName = "Jane", LastName = "Doe" }
                }
            ];

            return Task.FromResult(customers);
        }

        public Task<IReadOnlyList<CustomerLastPurchaseDto>> GetCustomerLastPurchases(int daysCount)
        {
            IReadOnlyList<CustomerLastPurchaseDto> customersPurchases =
            [
                new()
                {
                    Customer = new()
                    {
                        Id = Guid.NewGuid(),
                        FullName = new FullNameDto { FirstName = "John", LastName = "Doe" }
                    },
                    PurchaseDate = new DateOnly(2023, 12, 1)
                },
                new()
                {
                    Customer =  new()
                    {
                        Id = Guid.NewGuid(),
                        FullName = new FullNameDto { FirstName = "Jane", LastName = "Doe" }
                    },
                    PurchaseDate = new DateOnly(2021, 10, 10)
                }
            ];

            return Task.FromResult(customersPurchases);
        }

        public Task<IReadOnlyList<PurchasesPerCategoryDto>> GetCategoriesPurchasesCount(Guid customerId)
        {
            IReadOnlyList<PurchasesPerCategoryDto> categoriesPurchases =
            [
                new()
                {
                    CategoryName = "Phone",
                    PurchasesCount = 10
                },
                new()
                {
                    CategoryName = "TV",
                    PurchasesCount = 1
                }
            ];

            return Task.FromResult(categoriesPurchases);
        }
    }
}
