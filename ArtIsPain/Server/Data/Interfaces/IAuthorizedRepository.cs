using ArtIsPain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Interfaces
{
    public interface IAuthorizedRepository<TEntity> where TEntity : class, IEntity, IAuthorized, new()
    {
        public IQueryable<TEntity> GetEntityByAuthorId(
            Guid authorId,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}