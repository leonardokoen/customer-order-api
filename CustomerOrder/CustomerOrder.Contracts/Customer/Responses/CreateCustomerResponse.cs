using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Contracts.Customer.Responses
{
    public record CreateCustomerResponse(
        string Message,
        string FirstName,
        string LastName,
        string Email
     );
}
