using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Repositories
{
    public interface IRepository<T, Tkey> where T : BaseEntity<Tkey>
    {
        public DbSet<T> _entity { get; }
    }
}
