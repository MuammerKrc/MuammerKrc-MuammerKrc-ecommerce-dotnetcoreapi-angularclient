using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IProductRepositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories.ProductRepositories
{
    public class ProductReadRepository : ReadRepository<Product, Guid>, IProductReadRepository
    {
        public ProductReadRepository(AppDbContext context) : base(context)
        {

        }

    }
}
