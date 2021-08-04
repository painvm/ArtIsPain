using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared.Interfaces;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArtIsPain.Server.Data.Repositories
{
    public abstract class MultiAuthorizedEntityRepository<TEntity, TContext> : BaseRepository<TEntity, TContext>, IMultiAuthorizedRepository<TEntity>
                                                                                                                where TEntity : class, IMultiAuthorized, new()
                                                                                                                where TContext : DbContext
    {
        private readonly TContext _dataContext;

        public MultiAuthorizedEntityRepository(TContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<TEntity> GetByAuthorId(Guid authorId)
        {
            IQueryable<TEntity> authoredEntities =
                _dataContext.Set<TEntity>().Where(x => x.AuthorId == authorId);

            return authoredEntities;
        }

        public IQueryable<TEntity> SetAuthorship(Guid entityId, IEnumerable<Guid> authorIds)
        {
            IList<TEntity> authorship = new List<TEntity>();

            foreach (var authorId in authorIds)
            {
                TEntity entityAuthorPair = new TEntity();

                entityAuthorPair.EntityId = entityId;
                entityAuthorPair.AuthorId = authorId;

                authorship.Add(entityAuthorPair);
            }

            _dataContext.BulkInsertAsync<TEntity>(authorship);

            return base.GetAll(entities => entities.Where(x => x.EntityId == entityId));
        }
    }
}