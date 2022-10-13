using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.ProductImageQueries.GetProductImages
{
    public class GetProductImagesQueryRequest : IRequest<List<GetProductImagesQueryResponse>>
    {
        public Guid Id { get; set; }

    }
}
