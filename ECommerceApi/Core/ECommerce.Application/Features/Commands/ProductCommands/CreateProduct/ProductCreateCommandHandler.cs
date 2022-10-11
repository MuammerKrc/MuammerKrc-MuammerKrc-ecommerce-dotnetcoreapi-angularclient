using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IProductRepositories;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Commands.ProductCommands.CreateProduct
{

    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommandRequest, ProductCreateCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public ProductCreateCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }
        public async Task<ProductCreateCommandResponse> Handle(ProductCreateCommandRequest request, CancellationToken cancellationToken)
        {
            _productWriteRepository.Add(new Product()
            {
                Stock = request.Stock,
                Price = request.Price,
                Name = request.Name
            });
            await _productWriteRepository.SaveAsync();
            return new ProductCreateCommandResponse();
        }
    }
}
