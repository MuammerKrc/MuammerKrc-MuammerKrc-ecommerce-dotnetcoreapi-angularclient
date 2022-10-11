using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Features.Commands.ProductImageFileCommands.UploadProductImage
{
    public class UploadProductImageCommandRequest : IRequest<UploadProductImageCommandResponse>
    {
        public Guid Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
