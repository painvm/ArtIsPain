using ArtIsPain.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Upsert(T entity);

        Task<T> Delete(Guid id);
    }
}