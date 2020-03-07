using ArtIsPain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Interfaces
{
    public interface IMultiAuthorizedRepository<TEntity> where TEntity : class, IMultiAuthorized, new()
    {
        public IQueryable<TEntity> SetAuthorship(Guid entityId, IEnumerable<Guid> authorIds);

        public IQueryable<TEntity> GetByAuthorId(Guid authorId);
    }
}