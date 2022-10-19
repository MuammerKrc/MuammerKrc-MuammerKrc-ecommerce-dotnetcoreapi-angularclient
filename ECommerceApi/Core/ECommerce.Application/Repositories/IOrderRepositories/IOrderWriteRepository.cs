using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Repositories.IOrderRepositories
{
    public interface IOrderWriteRepository : IWriteRepository<Order, Guid>
    {
    }
}
