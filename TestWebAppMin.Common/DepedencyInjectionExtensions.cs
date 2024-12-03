using Microsoft.Extensions.DependencyInjection;
using TestWebAppMin.Services;

namespace TestWebAppMin.Common
{
    public static class DepedencyInjectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddTransient<ICustomerProvider, MockCustomerProvider>();
        }

        public static void AddDataAccess(this IServiceCollection services)
        {
        }
    }
}
