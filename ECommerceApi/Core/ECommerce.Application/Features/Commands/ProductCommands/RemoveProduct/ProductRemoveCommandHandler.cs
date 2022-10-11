using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IProductRepositories;
using MediatR;

namespace ECommerce.Application.Features.Commands.ProductCommands.RemoveProduct
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommandRequest, ProductRemoveCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductRemoveCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<ProductRemoveCommandResponse> Handle(ProductRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            var response=await _productReadRepository.GetByIdAsync(request.Id, true);
            _productWriteRepository.Remove(response);
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
