using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Queries.BasketQueries.GetBasketItem
{
    public class GetBasketItemQueryRequest : IRequest<List<GetBasketItemQueryResponse>>
    {
    }
}
