using CustomerOrder.Application.Services.CustomerServices.Common;
using MediatR;

namespace CustomerOrder.Application.Services.CustomerServices.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(
        Guid CustomerId,
        string Username,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Address,
        string PostalCode
     ) : IRequest<UpdateCustomerResult>;
}
