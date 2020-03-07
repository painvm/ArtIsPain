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

        public abstract Task<TEntity> Delete(Guid id);

        public IQueryable<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>().AsQueryable();
        }

        public abstract Task<TEntity> GetById(Guid id);

        public abstract Task<TEntity> Upsert(TEntity entity);
    }
}