using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderCommandRequest:IRequest<CreateOrderCommandResponse>
    {
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
