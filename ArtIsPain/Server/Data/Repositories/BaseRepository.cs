using ArtIsPain.Server.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class
                                                                          where TContext : DbContext
    {
        private readonly TContext _dataContext;

        public BaseRepository(TContext dataContext)
        {
            _dataContext = dataContext;
        }

        public abstract Task BulkDelete(IQueryable<TEntity> entities);

        public abstract Task<TEntity> Delete(Guid id);

        public IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate = null)
        {
             IQueryable<TEntity> query = _dataContext.Set<TEntity>().AsQueryable();

            if(predicate != null)
            {
                query = predicate(query);
            }

            return query;
        }

        public abstract IQueryable<TEntity> GetById(Guid id, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null);

        public abstract Task<TEntity> Upsert(TEntity entity, Func<IQueryable<TEntity>, IQueryable<TEntity>> addJoinStatement = null);
    }
}