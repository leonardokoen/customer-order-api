using CustomerOrder.Application.Services.CustomerServices.Common;
using MediatR;

namespace CustomerOrder.Application.Services.CustomerServices.Commands.CreateCustomer
{
    public record CreateCustomerCommand(
      string Username,
      string FirstName,
      string LastName,
      string Email,
      string Password,
      string Address,
      string PostalCode
   ) : IRequest<CreateCustomerResult>;
}
