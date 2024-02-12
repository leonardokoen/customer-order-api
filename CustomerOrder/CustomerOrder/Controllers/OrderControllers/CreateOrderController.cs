using CustomerOrder.Contracts.Orders.Requests;
using Microsoft.AspNetCore.Mvc;
using CustomerOrder.Contracts.Orders.Responses;
using MediatR;
using CustomerOrder.Application.Services.OrderServices.Commands.CreateOrder;
using CustomerOrder.Application.Services.OrderServices.Common;
using MapsterMapper;

namespace CustomerOrder.Api.Controllers.OrderServices
{
    [ApiController]
    [Route("api")]
    public class CreateOrderController : Controller
    {

        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CreateOrderController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("CreateOrder")] 
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var command = _mapper.Map<CreateOrderCommand>(request);
            CreateOrderResult createOrderResult = await _mediator.Send(command);
            var response = _mapper.Map<CreateOrderResponse>(createOrderResult);
            return Ok(response);
        }
    }
}
