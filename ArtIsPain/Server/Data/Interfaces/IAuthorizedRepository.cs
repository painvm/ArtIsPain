using ArtIsPain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Interfaces
{
    public interface IAuthorizedRepository<TEntity> where TEntity : class, IAuthorized, new()
    {
        public IQueryable<TEntity> GetEntitiesByAuthorId(
            Guid authorId,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        public IQueryable<TEntity> SetAuthorship(Guid entityId, IEnumerable<Guid> authorIds);
    }
}