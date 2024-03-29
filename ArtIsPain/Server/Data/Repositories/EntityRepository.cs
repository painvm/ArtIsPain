﻿using ArtIsPain.Shared.Interfaces;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public abstract class EntityRepository<TEntity, TContext> : BaseRepository<TEntity, TContext> where TEntity : class, IEntity
                                                                                                  where TContext : DbContext
    {
        private readonly TContext _dataContext;

        public EntityRepository(TContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<TEntity> Upsert(TEntity entityToUpsert, Func<IQueryable<TEntity>, IQueryable<TEntity>> addJoinStatement)
        {
            IQueryable<TEntity> a = _dataContext.Set<TEntity>();

            if (addJoinStatement != null)
            {
                a = addJoinStatement(a);
            }

            var entityFromDatabase = await a.FirstOrDefaultAsync(e => e.Id == entityToUpsert.Id);

            if (entityFromDatabase == null)
            {
                _dataContext.Set<TEntity>().Add(entityToUpsert);
            }
            else
            {
                _dataContext.Entry(entityFromDatabase).State = EntityState.Modified;
            }

            await _dataContext.SaveChangesAsync();

            return entityToUpsert;
        }

        public override async Task<TEntity> Delete(Guid id)
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }

            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }

        public override IQueryable<TEntity> GetById(Guid id, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            IQueryable<TEntity> getByIdQuery = _dataContext.Set<TEntity>();

            if (include != null)
            {
                getByIdQuery = include(getByIdQuery);
            }

            return getByIdQuery.Where(x => x.Id == id);
        }

        public override async Task BulkDelete(IQueryable<TEntity> entities)
        {
             _dataContext.BulkDelete(entities.ToList());
            await _dataContext.SaveChangesAsync();
        }
    }
}