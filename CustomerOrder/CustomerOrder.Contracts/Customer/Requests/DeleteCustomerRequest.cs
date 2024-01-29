using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Contracts.Customer.Requests
{
    public record DeleteCustomerRequest(
        string Email,
        string Password
     );
}
