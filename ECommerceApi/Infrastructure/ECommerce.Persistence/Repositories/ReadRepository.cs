using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Common;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class ReadRepository<TModel, TKey> : IReadRepository<TModel, TKey> where TModel : BaseEntity<TKey>
    {
        public readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<TModel> _entity => _context.Set<TModel>();

        public async Task<List<TModel>> GetAll(bool tracking = false)
        {
            var query = _entity.Where(i => true).AsQueryable();
            if (!tracking)
                query.AsNoTracking();
            return await query.ToListAsync();
        }

        public IQueryable<TModel> GetWhere(Expression<Func<TModel, bool>> method)
        {
            return _entity.Where(method).AsQueryable();
        }

        public async Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> method, bool tracking = false)
        {
            var query = _entity.Where(method).AsQueryable();
            if (!tracking)
                query.AsNoTracking();
            var response = await query.FirstOrDefaultAsync();
            if (response == null)
                throw new Exception(message: "Not found element ");
            return response;
        }


        public async Task<TModel> GetByIdAsync(TKey id, bool tracking = false)
        {
            var query = _entity.Where(i => i.Id.Equals(id)).AsQueryable();
            if (!tracking)
                query.AsNoTracking();
            var response = await query.FirstOrDefaultAsync();
            if (response == null)
                throw new Exception(message: "Not found element ");
            return response;
        }

    }
}
