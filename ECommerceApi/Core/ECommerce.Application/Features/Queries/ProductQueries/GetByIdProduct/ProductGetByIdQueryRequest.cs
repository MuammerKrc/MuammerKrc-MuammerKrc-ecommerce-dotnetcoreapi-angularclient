using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class ProductGetByIdQueryRequest : IRequest<ProductGetByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
