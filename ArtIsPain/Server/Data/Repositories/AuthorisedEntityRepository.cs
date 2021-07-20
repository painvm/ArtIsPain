using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ArtIsPain.Server.Data.Repositories
{
    public abstract class AuthorisedEntityRepository<TEntity, TContext> : EntityRepository<TEntity, TContext>, IAuthorizedRepository<TEntity>
                                                                                                              where TEntity : class, IEntity, IAuthorized, new()
                                                                                                              where TContext : DbContext
    {
        private readonly TContext _dataContext;

        public AuthorisedEntityRepository(TContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<TEntity> GetEntitiesByAuthorId(
            Guid authorId,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dataContext.Set<TEntity>();

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            IQueryable<Guid> authorizedPoetryVolumeIdList = query.Where(x => x.AuthorId == authorId).Select(x => x.Id);

            return query.Where(x => authorizedPoetryVolumeIdList.Contains(x.Id));
        }
    }
}