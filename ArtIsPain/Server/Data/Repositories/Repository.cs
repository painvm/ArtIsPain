using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity
                                                                               where TContext : DbContext
    {
        private readonly TContext _dataContext;

        public Repository(TContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> Delete(Guid id)
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }

            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dataContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();

            return entity;
        }
    }
}