using CustomerOrder.Application.Services.OrderServices.Common;
using MediatR;

namespace CustomerOrder.Application.Services.OrderServices.Queries.GetCustomerOrderHistory
{
    public record GetCustomersOrderHistoryQuiry
    (
        string Email
    ) : IRequest<GetCustomerOrderHistoryResult>;
}
