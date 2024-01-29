using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Contracts.Products.Requests
{
    public record CreateProductRequest(
        List<string> ProductNames,
        List<float> Prices
    );
}
