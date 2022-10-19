using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IOrderRepositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository:ReadRepository<Order,Guid> ,IOrderReadRepository
    {
        public OrderReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
