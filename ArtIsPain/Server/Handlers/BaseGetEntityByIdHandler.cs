using ArtIsPain.Server.Commands;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels;
using ArtIsPain.Shared;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers
{
    public abstract class BaseGetEntityByIdHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TResponse : IViewModel
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

        public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TEntity entity = await _entityRepository.GetById(request.EntityId);

            if (entity == null)
            {
                return default(TResponse);
            }

            TResponse entityToReturn = _autoMapper.Map<TResponse>(entity);

            return entityToReturn;
        }
    }
}