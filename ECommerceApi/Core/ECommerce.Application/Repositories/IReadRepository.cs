using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Application.Repositories
{
    public interface IReadRepository<TModel, TKey> : IRepository<TModel, TKey> where TModel : BaseEntity<TKey>
    {
        Task<List<TModel>> GetAll(bool tracking = false);
        IQueryable<TModel> GetWhere(Expression<Func<TModel, bool>> method);
        Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> method, bool tracking = false);
        Task<TModel> GetByIdAsync(TKey id, bool tracking = false);
    }
}
