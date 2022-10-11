using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IProductRepositories;
using MediatR;

namespace ECommerce.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQueryRequest, ProductGetByIdQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public ProductGetByIdQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<ProductGetByIdQueryResponse> Handle(ProductGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);
            return new ProductGetByIdQueryResponse()
            {
                Id = product.Id,
                Price = product.Price,
                Stock = product.Stock,
                Name = product.Name
            };
        }
    }
}
