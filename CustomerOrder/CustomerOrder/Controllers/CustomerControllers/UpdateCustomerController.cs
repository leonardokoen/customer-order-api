using CustomerOrder.Application.Services.CustomerServices;
using CustomerOrder.Application.Services.CustomerServices.Commands.UpdateCustomer;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Contracts.Customer.Requests;
using CustomerOrder.Contracts.Customer.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.CustomerControllers
{
    [ApiController]
    [Route("api")]

    public class UpdateCustomerController : Controller
    {
        private readonly ISender _mediator;

        public UpdateCustomerController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest request)
        {
            var command = new UpdateCustomerCommand(request.PreviousEmail,request.FirstName, request.LastName,request.Email, request.Password, request.Address, request.PostalCode);
            UpdateCustomerResult updateCustomerResult = await _mediator.Send(command);
            var response = new UpdateCustomerResponse(updateCustomerResult.Message, updateCustomerResult.Email);
            return Ok(response);
        }
    }
}
