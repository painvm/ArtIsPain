using ArtIsPain.Shared;
using ArtIsPain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public abstract class EntityRepository<TEntity, TContext> : BaseRepository<TEntity, TContext> where TEntity : class, IEntity
                                                                                                  where TContext : DbContext
    {
        private readonly TContext _dataContext;

        public EntityRepository(TContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<TEntity> Upsert(TEntity entityToUpsert)
        {
            var entityFromDatabase = await _dataContext.Set<TEntity>().FindAsync(entityToUpsert.Id);

            if (entityFromDatabase == null)
            {
                _dataContext.Set<TEntity>().Add(entityToUpsert);
            }
            else
            {
                _dataContext.Entry(entityFromDatabase).State = EntityState.Modified;
            }

            await _dataContext.SaveChangesAsync();

            return entityToUpsert;
        }

        public override async Task<TEntity> Delete(Guid id)
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

        public override async Task<TEntity> GetById(Guid id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }
    }
}