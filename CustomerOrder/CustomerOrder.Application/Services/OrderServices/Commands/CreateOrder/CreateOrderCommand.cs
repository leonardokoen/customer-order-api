using CustomerOrder.Application.Services.OrderServices.Common;
using MediatR;

namespace CustomerOrder.Application.Services.OrderServices.Commands.CreateOrder
{
    public record CreateOrderCommand(
        Guid CustomerId,
        List<string> ProductNames,
        List<int> ItemQuantity
    ) : IRequest<CreateOrderResult>;
}
