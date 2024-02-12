using CustomerOrder.Application.Services.CustomerServices.Commands.UpdateCustomer;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Contracts.Customer.Requests;
using CustomerOrder.Contracts.Customer.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.CustomerControllers
{
    [ApiController]
    [Route("api")]

    public class UpdateCustomerController : Controller
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UpdateCustomerController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest request)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(request);
            UpdateCustomerResult updateCustomerResult = await _mediator.Send(command);
            var response = _mapper.Map<UpdateCustomerResponse>(updateCustomerResult);
            return Ok(response);
        }
    }
}
