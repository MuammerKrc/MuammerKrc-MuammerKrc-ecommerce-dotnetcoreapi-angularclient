using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IProductRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Queries.ProductQueries.GetAllProduct
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQueryRequest, ProductGetAllQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public ProductGetAllQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<ProductGetAllQueryResponse> Handle(ProductGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _productReadRepository.GetWhere(i => true).Count();
            var products = await _productReadRepository.GetWhere(i => true).Skip(request.Page * request.Size)
                .Take(request.Size).ToListAsync();
            return new()
            {
                Products = products,
                TotalProductCount = totalCount
            };
        }
    }
}
