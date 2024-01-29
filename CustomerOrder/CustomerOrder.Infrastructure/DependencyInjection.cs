using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Infrastructure.Common;
using CustomerOrder.Infrastructure.CustomerInfrastructure;
using CustomerOrder.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace CustomerOrder.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return services;
        }
    }
}
