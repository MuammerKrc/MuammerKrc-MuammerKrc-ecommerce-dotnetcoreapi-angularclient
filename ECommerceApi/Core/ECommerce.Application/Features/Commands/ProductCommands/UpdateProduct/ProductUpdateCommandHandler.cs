using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IProductRepositories;
using MediatR;

namespace ECommerce.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommandRequest, ProductUpdateCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public ProductUpdateCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<ProductUpdateCommandResponse> Handle(ProductUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id, true);
            product.Stock = request.Stock;
            product.Price = request.Price;
            product.Name = request.Name;
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
