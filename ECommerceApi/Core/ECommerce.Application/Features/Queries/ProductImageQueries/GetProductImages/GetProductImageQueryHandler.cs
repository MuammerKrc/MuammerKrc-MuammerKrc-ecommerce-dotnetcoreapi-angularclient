using ECommerce.Application.Repositories.IProductRepositories;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.ProductImageQueries.GetProductImages
{
    public class GetProductImageQueryHandler : IRequestHandler<GetProductImagesQueryRequest, List<GetProductImagesQueryResponse>>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IConfiguration _configuration;

        public GetProductImageQueryHandler(IConfiguration configuration, IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;

            _configuration = configuration;
        }
        public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadRepository._entity.Include(i => i.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == request.Id);
            if (product != null)
                return product.ProductImageFiles?.Select(i => new GetProductImagesQueryResponse()
                {
                    Path = $"{_configuration["BaseStorageUrl"]}/{i.Path}",
                    FileName = i.FileName,
                    Id = i.Id
                }).ToList() ?? new List<GetProductImagesQueryResponse>();

            throw new Exception("NotFound");
        }
    }
}
