using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IProductImageFileRepositories;
using ECommerce.Application.Repositories.IProductRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Commands.ProductImageFileCommands.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;


        public RemoveProductImageCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetWhere(i => i.Id == request.Id)
                .Include(i => i.ProductImageFiles).FirstOrDefaultAsync();

            if (product != null)
            {
                var prductImageFile = product.ProductImageFiles.FirstOrDefault(i => i.Id == request.ImageId);
                if (prductImageFile != null)
                {
                    product.ProductImageFiles.Remove(prductImageFile);
                    await _productWriteRepository.SaveAsync();
                }
            }
            return new();
        }
    }
}
