using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IBasketRepositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.BasketRepository
{
    public class BasketReadRepository:ReadRepository<Basket,Guid>,IBasketReadRepository
    {
        public BasketReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
