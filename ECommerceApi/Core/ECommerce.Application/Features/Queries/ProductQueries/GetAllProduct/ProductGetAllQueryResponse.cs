using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Queries.ProductQueries.GetAllProduct
{
    public class ProductGetAllQueryResponse
    {
        public int TotalProductCount { get; set; }
        public List<Product> Products { get; set; }
    }
}
