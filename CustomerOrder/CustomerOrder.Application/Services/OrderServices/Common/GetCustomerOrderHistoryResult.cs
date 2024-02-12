using CustomerOrder.Application.Common.Interfaces;


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

        string Message,
        List<OrderResult> OrderResults
    ): IResult;
}
