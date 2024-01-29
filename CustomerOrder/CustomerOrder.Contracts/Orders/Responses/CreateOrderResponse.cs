using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Contracts.Orders.Responses
{
    public record CreateOrderResponse(
        string message,
        List<string> ProductNames,
        List<int> ItemQuantity,
        List<float> ItemCost,
        DateTime DateOrder,
        float total_value
 );
}
