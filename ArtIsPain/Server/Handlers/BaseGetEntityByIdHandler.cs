using ArtIsPain.Server.Commands;
using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Shared;
using ArtIsPain.Shared.Interfaces;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers
{
    public abstract class BaseGetEntityByIdHandler<TEntity, TRequest, TResponse> : BaseHandler<TEntity, TRequest, TResponse> where TResponse : IViewModel
                                                                                                                             where TRequest : IGetEntityByIdCommand<TResponse>
                                                                                                                             where TEntity : class, IEntity
    {
        private readonly IMapper _autoMapper;
        private readonly IRepository<TEntity> _entityRepository;

        public BaseGetEntityByIdHandler(
            IMapper autoMapper,
            IRepository<TEntity> entityRepository)
        {
            _autoMapper = autoMapper;
            _entityRepository = entityRepository;
        }

        protected override async Task<TResponse> Send(TRequest request, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            IQueryable<TEntity> entity = _entityRepository.GetById(request.EntityId, include);
            TResponse entityToReturn = await _autoMapper.ProjectTo<TResponse>(entity).FirstOrDefaultAsync();

            return entityToReturn;
        }
    }
}