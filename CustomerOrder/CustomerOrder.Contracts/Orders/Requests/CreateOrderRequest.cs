namespace CustomerOrder.Contracts.Orders.Requests
{
    public record CreateOrderRequest(
        Guid CustomerId,
        List<string> ProductNames,
        List<int> ItemQuantity
    );
}
