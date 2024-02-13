using CustomerOrder.Application.Services.OrderServices.Commands.CreateOrder;
using CustomerOrder.Application.Services.OrderServices.Common;
using CustomerOrder.Application.Services.OrderServices.Queries.GetCustomerOrderHistory;
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

            config.NewConfig<GetCustomerOrderHistoryRequest, GetCustomersOrderHistoryQuiry>();
            config.NewConfig<List<OrderResult>, List<OrderResponse>>();
            config.NewConfig<(GetCustomerOrderHistoryResult Result, List<OrderResponse> ListResponse), GetCustomersOrderHistoryResponse>()
                .Map(dest => dest.Message, src => src.Result.Message)
                .Map(dest => dest.OrderResponses, src => src.ListResponse);
        }
    }
}
