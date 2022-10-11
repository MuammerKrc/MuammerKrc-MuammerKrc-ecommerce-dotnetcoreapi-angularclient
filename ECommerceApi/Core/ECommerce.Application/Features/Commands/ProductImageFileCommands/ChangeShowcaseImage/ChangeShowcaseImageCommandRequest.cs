using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Commands.ProductImageFileCommands.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandRequest:IRequest<ChangeShowcaseImageCommandResponse>
    {
        public string ImageId { get; set; }
        public string ProductId { get; set; }
    }
}
