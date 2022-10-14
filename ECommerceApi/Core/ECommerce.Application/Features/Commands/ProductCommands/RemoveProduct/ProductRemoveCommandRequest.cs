using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Commands.ProductCommands.RemoveProduct
{
    public class ProductRemoveCommandRequest : IRequest<ProductRemoveCommandResponse>
    {
        public Guid id { get; set; }
    }
}
