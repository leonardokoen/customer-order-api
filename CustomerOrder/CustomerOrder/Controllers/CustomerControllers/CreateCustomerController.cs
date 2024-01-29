using CustomerOrder.Application.Services.CustomerServices.Commands.CreateCustomer;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Contracts.Customer;
using CustomerOrder.Contracts.Customer.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.Customer
{
    [ApiController]
    [Route("api")]
    public class CreateCustomerController : Controller
    {


        private readonly ISender _mediator;

        public CreateCustomerController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            var command = new CreateCustomerCommand(request.FirstName, request.LastName, request.Address, request.PostalCode, request.Email, request.Password);
            CreateCustomerResult createCustomerResult = await _mediator.Send(command);
            var response = new CreateCustomerResponse(createCustomerResult.Message, createCustomerResult.FirstName, createCustomerResult.LastName, createCustomerResult.Email);
            return Ok(response);
        }
    }
}
