namespace CustomerOrder.Contracts.Customer
{
    public record CreateCustomerRequest(
        string Username,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Address,
        string PostalCode
     );
}
