using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IOrderRepositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.OrderRepository
{
    public class OrderWriteRepository:WriteRepository<Order,Guid>,IOrderWriteRepository
    {
        public OrderWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
