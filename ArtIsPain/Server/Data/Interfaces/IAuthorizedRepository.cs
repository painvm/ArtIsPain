using ArtIsPain.Shared;
using System;
using System.Linq;

namespace ArtIsPain.Server.Data.Interfaces
{
    public interface IAuthorizedRepository<TEntity> where TEntity : class, IAuthorized, new()
    {
        public IQueryable<TEntity> GetEntitiesByAuthorId(
            Guid authorId,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}