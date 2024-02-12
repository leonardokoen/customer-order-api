using CustomerOrder.Application.Services.CustomerServices.Common;
using MediatR;

namespace CustomerOrder.Application.Services.CustomerServices.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand(
      Guid CustomerId
   ) : IRequest<DeleteCustomerResult>;
}
