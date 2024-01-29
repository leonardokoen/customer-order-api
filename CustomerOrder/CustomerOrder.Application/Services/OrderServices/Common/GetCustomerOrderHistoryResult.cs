using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Application.Services.OrderServices.Common
{
    public class OrderResult
    {

        public List<string> ProductNames { get; set; }

        public List<int> ItemQuantity { get; set; }

        public List<float> ItemCost { get; set; }

        public float TotalCost { get; set; }

        public DateTime OrderDate { get; set; }
    }
    public record GetCustomerOrderHistoryResult(
    List<OrderResult> OrderResults
);
}
