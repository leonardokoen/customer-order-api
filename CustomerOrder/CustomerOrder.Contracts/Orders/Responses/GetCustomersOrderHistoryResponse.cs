using CustomerOrder.Contracts.Common;

namespace CustomerOrder.Contracts.Orders.Responses
{
    public class OrderResponse
    {

        public List<string> ProductNames { get; set; }

        public List<int> ItemQuantity { get; set; }

        public List<float> ItemCost { get; set; }

        public float TotalCost { get; set; }

        public DateTime OrderDate { get; set; }
    }

    public record GetCustomersOrderHistoryResponse(

        string Message,
        List<OrderResponse> OrderResponses
    ) : IResponse;
}
