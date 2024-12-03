using Microsoft.Extensions.DependencyInjection;
using TestWebAppMin.DataAccess;
using TestWebAppMin.Services;

namespace TestWebAppMin.Common
{
    public static class DepedencyInjectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddTransient<ICustomerProvider, CustomerProvider>();
        }

        public static void AddDataAccess(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
