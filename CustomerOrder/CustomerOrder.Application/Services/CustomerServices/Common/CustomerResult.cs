namespace CustomerOrder.Application.Services.CustomerServices.Common
{
    public record CreateCustomerResult(
        string Message,
        string FirstName,
        string LastName,
        string Email
     );

    public record DeleteCustomerResult(
        string Message,
        string Email
    );

    public record UpdateCustomerResult(
        string Message,
        string Email
    );
}
