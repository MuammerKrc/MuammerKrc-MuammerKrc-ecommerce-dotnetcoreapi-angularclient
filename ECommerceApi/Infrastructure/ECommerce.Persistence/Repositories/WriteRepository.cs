using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Common;
using ECommerce.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class WriteRepository<TModel, TKey> : IWriteRepository<TModel, TKey> where TModel : BaseEntity<TKey>
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<TModel> _entity => _context.Set<TModel>();
        public bool Add(TModel model)
        {
            _context.Entry<TModel>(model).State = EntityState.Added;
            return _context.Entry<TModel>(model).State == EntityState.Added;
        }

        public bool AddRange(List<TModel> datas)
        {
            datas.ForEach(i => _context.Entry<TModel>(i).State = EntityState.Added);
            return !datas.Any(i => _context.Entry<TModel>(i).State != EntityState.Added);
        }
        public bool Remove(TModel model, bool softDelete = true)
        {
            if ((model is SoftDeleteBaseEntity<TKey> || model is FullAuditBaseEntity<TKey>) && softDelete)
            {
                if (model is SoftDeleteBaseEntity<TKey>)
                    (model as SoftDeleteBaseEntity<TKey>).IsDeleted = true;
                if (model is FullAuditBaseEntity<TKey>)
                    (model as FullAuditBaseEntity<TKey>).IsDeleted = true;

                return true;
            }
            else
            {
                _context.Entry<TModel>(model).State = EntityState.Deleted;
                return _context.Entry<TModel>(model).State == EntityState.Deleted;
            }
        }

        public bool RemoveRange(List<TModel> datas, bool softDelete = true)
        {
            if ((datas is SoftDeleteBaseEntity<TKey> || datas is FullAuditBaseEntity<TKey>) && softDelete)
            {
                if (datas is SoftDeleteBaseEntity<TKey>)
                    (datas as SoftDeleteBaseEntity<TKey>).IsDeleted = true;
                if (datas is FullAuditBaseEntity<TKey>)
                    (datas as FullAuditBaseEntity<TKey>).IsDeleted = true;
                return true;
            }
            else
            {
                _context.Entry<List<TModel>>(datas).State = EntityState.Deleted;
                return _context.Entry<List<TModel>>(datas).State == EntityState.Deleted;
            }
        }
        public bool Update(TModel model)
        {
            _context.Entry<TModel>(model).State = EntityState.Modified;
            return _context.Entry<TModel>(model).State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(i =>
            {
                if (i.Entity is BaseEntity<TKey> model)
                {
                    if (i.State == EntityState.Added)
                    {
                        model.CreationDate = DateTime.Now;
                    }
                    if (i.State == EntityState.Modified)
                    {
                        model.UpdateDate = DateTime.Now;
                    }
                    if (i.State == EntityState.Deleted)
                    {
                        if (i.Entity is SoftDeleteBaseEntity<TKey>)
                        {
                            (model as SoftDeleteBaseEntity<TKey>).IsDeleted = true;
                            i.State = EntityState.Modified;
                        }
                        if (i.Entity is FullAuditBaseEntity<TKey>)
                        {
                            (model as FullAuditBaseEntity<TKey>).IsDeleted = true;
                            i.State = EntityState.Modified;
                        }
                    }
                }

            });
            return await _context.SaveChangesAsync();
        }
    }
}
