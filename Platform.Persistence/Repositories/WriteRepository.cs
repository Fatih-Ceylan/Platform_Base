﻿using Platform.Application.Repositories;
using Platform.Domain.Entities.Common;
using Platform.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Platform.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly PlatformDbContext _context;
        public WriteRepository(PlatformDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool SoftDelete(T model)
        {
            model.IsDeleted = true;
            model.DeletedDate = DateTime.Now;
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(model);
        }

        public async Task<bool> SoftDeleteAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            model.IsDeleted = true;
            model.DeletedDate = DateTime.Now;
            EntityEntry<T> entityEntry = Table.Update(model);

            return entityEntry.State == EntityState.Modified;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public bool SoftDeleteRange(List<T> datas)
        {
            foreach (T data in datas)
            {
                data.IsDeleted = true;
                data.DeletedDate = DateTime.Now;
            }
            Table.UpdateRange(datas);

            return true;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public bool UpdateRange(List<T> datas)
        {
            Table.UpdateRange(datas);
            return true;
        }

        public async Task<int> SaveAsync()
         => await _context.SaveChangesAsync();

    }
}
