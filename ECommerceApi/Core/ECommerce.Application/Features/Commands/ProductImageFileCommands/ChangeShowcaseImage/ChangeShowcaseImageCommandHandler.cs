using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Commands.ProductImageFileCommands.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandHandler:IRequestHandler<ChangeShowcaseImageCommandRequest,ChangeShowcaseImageCommandResponse>
    {
        public Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
