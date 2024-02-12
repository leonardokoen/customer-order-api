using CustomerOrder.Application.Common.Interfaces;

namespace CustomerOrder.Application.Services.OrderServices.Common
{
    public record CreateOrderResult(
        string Message,
        List<string> ProductNames,
        List<int> ItemQuantity,
        List<float> ItemCost,
        DateTime DateOrder,
        float total_value
 ):IResult;
}
