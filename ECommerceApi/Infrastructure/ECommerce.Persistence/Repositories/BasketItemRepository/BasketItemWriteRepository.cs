using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IBasketItemRepositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.BasketItemRepository
{
    public class BasketItemWriteRepository:WriteRepository<BasketItem,Guid>,IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
