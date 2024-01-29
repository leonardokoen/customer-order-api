using CustomerOrder.Application.Services.OrderServices.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Application.Services.OrderServices.Commands.CreateOrder
{
    public record CreateOrderCommand(
        string Email,
        List<string> ProductNames,
        List<int> ItemQuantity
    ) : IRequest<CreateOrderResult>;
}
