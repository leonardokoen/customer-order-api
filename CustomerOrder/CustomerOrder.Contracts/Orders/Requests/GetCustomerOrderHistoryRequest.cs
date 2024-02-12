using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Contracts.Orders.Requests
{
    public record GetCustomerOrderHistoryRequest(
        Guid CustomerId
    );
    
}
