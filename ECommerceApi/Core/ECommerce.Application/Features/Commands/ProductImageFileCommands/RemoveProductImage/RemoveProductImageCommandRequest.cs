using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Commands.ProductImageFileCommands.RemoveProductImage
{
    public class RemoveProductImageCommandRequest : IRequest<RemoveProductImageCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
    }
}
