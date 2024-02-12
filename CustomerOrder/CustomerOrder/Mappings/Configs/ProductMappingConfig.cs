using Mapster;
using CustomerOrder.Contracts.Products.Requests;
using CustomerOrder.Application.Services.ProductServices.Commands;
using CustomerOrder.Application.Services.ProductServices.Common;
using CustomerOrder.Contracts.Products.Responses;
using CustomerOrder.Contracts.Orders.Requests;
using CustomerOrder.Application.Services.OrderServices.Queries.GetCustomerOrderHistory;
using CustomerOrder.Application.Services.OrderServices.Common;
using CustomerOrder.Contracts.Orders.Responses;

namespace CustomerOrder.Api.Mappings.Configs
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProductRequest, CreateProductCommand>();
            config.NewConfig<CreateProductResult, CreateProductResponse>();

            config.NewConfig<GetCustomerOrderHistoryRequest, GetCustomersOrderHistoryQuiry>();
            config.NewConfig<GetCustomerOrderHistoryResult, OrderResponse>();

        }
    }
}
