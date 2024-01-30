using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Domain.Entities;
using MediatR;

namespace CustomerOrder.Application.Services.CustomerServices.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
    {

        private readonly IUnitOfWork _unitOfWork;
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            if (_unitOfWork.Customer.GetCustomerByEmail(command.Email) == null)
            {
                var customer = new Customer
                {
                    Name = command.FirstName + " " + command.LastName,
                    Email = command.Email,
                    Password = command.Password,
                    Address = command.Address,
                    PostalCode = command.PostalCode
                };

                _unitOfWork.Customer.Add(customer);
                await _unitOfWork.Commit();
                return new CreateCustomerResult("Customer Creation was Succesful.", command.FirstName, command.LastName, command.Email);
            }

            throw new Exception("User with given email already exists");
        }
    }
}
