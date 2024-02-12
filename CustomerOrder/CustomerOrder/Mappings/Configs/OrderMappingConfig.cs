using CustomerOrder.Application.Services.OrderServices.Commands.CreateOrder;
using CustomerOrder.Application.Services.OrderServices.Common;
using CustomerOrder.Contracts.Orders.Requests;
using CustomerOrder.Contracts.Orders.Responses;
using Mapster;

namespace CustomerOrder.Api.Mappings.Configs
{
    public class OrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateOrderRequest, CreateOrderCommand>();
            config.NewConfig<CreateOrderResult, CreateOrderResponse>();

        }
    }
}
