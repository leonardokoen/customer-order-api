using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Contracts.Customer
{
    public record CreateCustomerRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Address,
        string PostalCode
     );
}
