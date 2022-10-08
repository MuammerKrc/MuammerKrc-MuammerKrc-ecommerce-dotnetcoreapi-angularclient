using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Application.Repositories
{
    public interface IWriteRepository<TModel, Tkey> : IRepository<TModel, Tkey> where TModel : BaseEntity<Tkey>
    {
        bool Add(TModel model);
        bool AddRange(List<TModel> datas);
        bool Remove(TModel model, bool softDelete = true);
        bool RemoveRange(List<TModel> datas, bool softDelete = true);
        bool Update(TModel model);
        Task<int> SaveAsync();
    }
}
