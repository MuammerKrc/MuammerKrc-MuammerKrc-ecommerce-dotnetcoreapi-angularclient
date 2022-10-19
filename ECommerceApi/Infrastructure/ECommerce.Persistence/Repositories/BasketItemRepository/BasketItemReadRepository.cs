using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IBasketItemRepositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories.BasketItemRepository
{
    public class BasketItemReadRepository:ReadRepository<BasketItem,Guid>,IBasketItemReadRepository
    {
        public BasketItemReadRepository(AppDbContext context) : base(context)
        {

        }
    }
}
