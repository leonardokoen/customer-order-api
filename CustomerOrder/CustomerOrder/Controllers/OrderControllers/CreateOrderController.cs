using CustomerOrder.Contracts.Orders.Requests;
using Microsoft.AspNetCore.Mvc;
using CustomerOrder.Contracts.Orders.Responses;
using MediatR;
using CustomerOrder.Application.Services.CustomerServices.Commands.CreateCustomer;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Contracts.Customer.Responses;
using CustomerOrder.Contracts.Customer;
using CustomerOrder.Application.Services.OrderServices.Commands.CreateOrder;
using CustomerOrder.Application.Services.OrderServices.Common;

namespace CustomerOrder.Api.Controllers.OrderServices
{
    [ApiController]
    [Route("api")]
    public class CreateOrderController : Controller
    {

        private readonly ISender _mediator;

        public CreateOrderController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOrder")] 
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var command = new CreateOrderCommand(request.Email, request.ProductNames, request.ItemQuantity);
            CreateOrderResult createOrderResult = await _mediator.Send(command);
            var response = new CreateOrderResponse(createOrderResult.message, createOrderResult.ProductNames, createOrderResult.ItemQuantity,createOrderResult.ItemCost,createOrderResult.DateOrder, createOrderResult.total_value);
            return Ok(response);
        }
    }
}
