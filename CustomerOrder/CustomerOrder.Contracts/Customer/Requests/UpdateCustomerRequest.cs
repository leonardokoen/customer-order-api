﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Contracts.Customer.Requests
{
    public record UpdateCustomerRequest(
        Guid CustomerId,
        string Username,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Address,
        string PostalCode
     );
}
