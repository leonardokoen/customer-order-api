using CustomerOrder.Application.Services.OrderServices.Common;
using CustomerOrder.Application.Services.OrderServices.Queries.GetCustomerOrderHistory;
using CustomerOrder.Application.Services.ProductServices.Commands;
using CustomerOrder.Application.Services.ProductServices.Common;
using CustomerOrder.Contracts.Orders.Requests;
using CustomerOrder.Contracts.Orders.Responses;
using CustomerOrder.Contracts.Products.Requests;
using CustomerOrder.Contracts.Products.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.ProductController
{
    [ApiController]
    [Route("api")]
    public class GetCustomerOrderHistoryController : Controller
    {

        private readonly ISender _mediator;

        public GetCustomerOrderHistoryController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetCustomerOrderHistory")]
        public async Task<IActionResult> GetCustomerOrderHistory (GetCustomerOrderHistoryRequest request)
        {
            var command = new GetCustomersOrderHistoryQuiry(request.Email);
            GetCustomerOrderHistoryResult createProductResult = await _mediator.Send(command);
            
            List<OrderResponse> orderResponse = new List<OrderResponse>();
            for (var i = 0 ; i < createProductResult.OrderResults.Count; i++) {
                var order = new OrderResponse
                { 
                    ItemCost = createProductResult.OrderResults[i].ItemCost,
                    ItemQuantity = createProductResult.OrderResults[i].ItemQuantity,
                    OrderDate = createProductResult.OrderResults[i].OrderDate,
                    ProductNames = createProductResult.OrderResults[i].ProductNames,
                    TotalCost = createProductResult.OrderResults[i].TotalCost
                };
                orderResponse.Add(order);
            }

            var response = new GetCustomersOrderHistoryResponse(orderResponse);
            return Ok(response);
        }
    }
}
