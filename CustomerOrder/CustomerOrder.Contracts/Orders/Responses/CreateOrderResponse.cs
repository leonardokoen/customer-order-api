using CustomerOrder.Contracts.Common;

namespace CustomerOrder.Contracts.Orders.Responses
{
    public record CreateOrderResponse(
        string Message,
        List<string> ProductNames,
        List<int> ItemQuantity,
        List<float> ItemCost,
        DateTime DateOrder,
        float TotalValue
 ) : IResponse;
}
