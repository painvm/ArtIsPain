﻿using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared;
using ArtIsPain.Shared.Interfaces;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            IQueryable<TEntity> query = include(_dataContext.Set<TEntity>());

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            IQueryable<Guid> authorizedPoetryVolumeIdList = query.Where(x => x.AuthorId == authorId).Select(x => x.Id);

            return query.Where(x => authorizedPoetryVolumeIdList.Contains(x.Id));
        }
    }
}