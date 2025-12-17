using CarService2.BL.Interfaces;
using CarService2.BL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarService2.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection
            AddBusinessLayerServices(this IServiceCollection services)
        {
            // Register your business layer services here e.g., services, mappers, etc.
            services
                .AddSingleton<ICustomerService, CustomerService>();

            return services;
        }
    }
}
