using CustomerOrder.Contracts.Common;

namespace CustomerOrder.Contracts.Customer.Responses
{
    public record DeleteCustomerResponse(
        string Message
     ) : IResponse;
}
