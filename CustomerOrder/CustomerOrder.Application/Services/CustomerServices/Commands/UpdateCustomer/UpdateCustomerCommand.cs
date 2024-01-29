using CustomerOrder.Application.Services.CustomerServices.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Application.Services.CustomerServices.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(
        string PreviousEmail,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Address,
        string PostalCode
     ) : IRequest<UpdateCustomerResult>;
}
