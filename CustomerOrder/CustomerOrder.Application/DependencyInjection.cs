using CustomerOrder.Application.Services.CustomerServices;
using CustomerOrder.Application.Services.OrderServices;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
namespace CustomerOrder.Application
{
    public static class DependencyInjection {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            //services.AddScoped<ICustomerService, CustomerService>();
            //services.AddScoped<IOrderService, OrderService>();
            return services;
        }

    }
}
