using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Domain.Entities;
using MediatR;

namespace CustomerOrder.Application.Services.CustomerServices.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResult>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            Customer ? customer = _unitOfWork.Customer.GetCustomerById(command.CustomerId);

            if (customer == null)
            {
                throw new Exception("User does not exist.");
            }

            //TODO: Better Validation
            if ((command.Email != customer.Email) && (_unitOfWork.Customer.GetCustomerByEmail(command.Email) != null))
            {
                throw new Exception("Email already exists.");
            }

            if ((command.Username != customer.Username) && (_unitOfWork.Customer.GetCustomerByUsername(command.Username) != null))
            {
                throw new Exception("Username already exists.");
            }

            var updatedCustomer = new Customer
            {
                Username = (!string.IsNullOrWhiteSpace(command.Username)) ? command.Username : customer.Username,
                Name = BuildName(command, customer),
                Email = (!string.IsNullOrWhiteSpace(command.Email)) ? command.Email : customer.Email,
                Password = (!string.IsNullOrWhiteSpace(command.Password)) ? command.Password : customer.Password,
                Address = (!string.IsNullOrWhiteSpace(command.Address)) ? command.Address : customer.Address,
                PostalCode = (!string.IsNullOrWhiteSpace(command.PostalCode)) ? command.PostalCode : customer.PostalCode
            };
            _unitOfWork.Customer.Update(updatedCustomer, customer.Id);
            await _unitOfWork.Commit();
            return new UpdateCustomerResult("Customer has been successfully updated.");
        }

        private string GetWordByIndex(string input, int index)
        {
            // Split the string into an array of words
            string[] words = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Return the first word if the array is not empty, otherwise return an empty string
            return words.Length > 0 ? words[index] : string.Empty;
        }

        private string BuildName(UpdateCustomerCommand command, Customer customer) {

            string name = string.Empty;
            if (!string.IsNullOrWhiteSpace(command.FirstName))
            {
                name = $"{command.FirstName}";
            }
            else
            {
                name = $"{GetWordByIndex(customer.Name, 0)}";
            }
            if (!string.IsNullOrWhiteSpace(command.LastName))
            {
                name += $" {command.LastName}";
            }
            else
            {
                name += $" {GetWordByIndex(customer.Name, 1)}";
            }
            return name;
        }
    }
}
