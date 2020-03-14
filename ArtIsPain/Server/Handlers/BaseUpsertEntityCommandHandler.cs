using ArtIsPain.Server.Commands;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels;
using ArtIsPain.Shared;
using ArtIsPain.Shared.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers
{
    public abstract class BaseUpsertEntityCommandHandler<TEntity, TRequest, TResponse> : BaseHandler<TEntity, TRequest, TResponse> where TResponse : IViewModel, new()
                                                                                                                                   where TRequest : IUpsertEntityCommand<TResponse>
                                                                                                                                   where TEntity : class, IEntity, new()
    {
        protected readonly IMapper _autoMapper;
        private readonly IRepository<TEntity> _repository;

        public BaseUpsertEntityCommandHandler(IMapper autoMapper, IRepository<TEntity> repository)
        {
            _autoMapper = autoMapper;
            _repository = repository;
        }

        protected override async Task<TResponse> Send(TRequest request, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            TEntity entityToUpsert = request.EntityId.HasValue
                ? await _repository.GetById(request.EntityId.Value).FirstOrDefaultAsync()
                : new TEntity();
            _autoMapper.Map(request, entityToUpsert);

            TEntity upsertedEntity = await _repository.Upsert(entityToUpsert);
            TResponse result = new TResponse();

            _autoMapper.Map(upsertedEntity, result);

            return result;
        }
    }
}