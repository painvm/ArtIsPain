using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(Func<IQueryable<T>, IQueryable<T>> searchCondition = null);

        IQueryable<T> GetById(Guid id, Func<IQueryable<T>, IQueryable<T>> addJoinStatement = null);

        Task<T> Upsert(T entity, Func<IQueryable<T>, IQueryable<T>> addJoinStatement = null);

        Task<T> Delete(Guid id);

        Task BulkDelete(IQueryable<T> entities);
    }
}