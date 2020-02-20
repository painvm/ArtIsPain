using ArtIsPain.Server.Commands;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Dtos;
using ArtIsPain.Shared;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Band
{
    public abstract class BaseUpsertEntityCommandHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TResponse : IViewModel, new()
                                                                                                                     where TRequest : IUpsertEntityCommand<TResponse>
                                                                                                                     where TEntity : class, IEntity, new()
    {
        private readonly IMapper _autoMapper;
        private readonly IRepository<TEntity> _repository;

        public BaseUpsertEntityCommandHandler(IMapper autoMapper, IRepository<TEntity> repository)
        {
            _autoMapper = autoMapper;
            _repository = repository;
        }

        public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TEntity entityToUpsert = request.EntityId.HasValue
                ? await _repository.GetById(request.EntityId.Value)
                : new TEntity();
            _autoMapper.Map(request, entityToUpsert);

            TEntity upsertedEntity = await _repository.Upsert(entityToUpsert);
            TResponse result = new TResponse();

            _autoMapper.Map(upsertedEntity, result);

            return result;
        }
    }
}