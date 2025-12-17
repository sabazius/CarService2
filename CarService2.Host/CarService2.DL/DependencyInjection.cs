using CarService2.DL.Interfaces;
using CarService2.DL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarService2.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection
            AddDataLayerServices(this IServiceCollection services)
        {
            // Register your data layer services here e.g., repositories, DbContext, etc.
            services
                .AddSingleton<ICustomerStaticRepository, CustomerStaticRepository>();

            return services;
        }
    }
}
