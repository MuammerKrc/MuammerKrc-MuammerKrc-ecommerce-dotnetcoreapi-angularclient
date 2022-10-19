using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Queries.OrderQueries.GetOrderById
{
    public class GetOrderByIdQueryRequest:IRequest<GetOrderByIdQueryResponse>
    {
        public Guid Id { get; set; }

    }
}
