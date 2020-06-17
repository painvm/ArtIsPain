using ArtIsPain.Server.Commands;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels;
using ArtIsPain.Shared.Interfaces;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers
{
    public abstract class BaseUpsertParentEntityHandler<TEntity, TChildEntity, TRequest, TChildResponse, TResponse> : BaseUpsertEntityCommandHandler<TEntity, TRequest, TResponse> where TResponse : IViewModel, new()
                                                                                                                                   where TRequest : IUpsertEntityCommand<TResponse>
                                                                                                                                   where TChildResponse : class, IViewModel
                                                                                                                                   where TEntity : class, IEntity, new()
                                                                                                                                   where TChildEntity : class, IEntity, IVolumeItem, new()

    {
        private readonly IRepository<TEntity> _repository;
        private readonly IRepository<TChildEntity> _childEntityRepository;

        public BaseUpsertParentEntityHandler(IMapper autoMapper, IRepository<TEntity> repository, IRepository<TChildEntity> childEntityRepository) : base(autoMapper, repository)
        {
            _repository = repository;
            _childEntityRepository = childEntityRepository;
        }

        protected async Task<TResponse> Send(TRequest request, Func<TResponse, ICollection<TChildResponse>> getChildEntitiesMethod, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IQueryable<TEntity>> addJoinStatement = null)
        {
            TResponse response = await base.Send(request, cancellationToken, addJoinStatement);
            var actualSongIds = getChildEntitiesMethod.Invoke(response).Select(x => x.Id);

            if (request.EntityId.HasValue)
            {
                if (actualSongIds.Count() > 0)
                {
                    RemoveChildEntities(request, actualSongIds);
                }
            }

            return response;
        }

        protected void RemoveChildEntities(TRequest request, IEnumerable<Guid> entityIds) 
        {
            if (request.EntityId.HasValue)
            {
                IQueryable<TChildEntity> childEntities = _childEntityRepository
                    .GetAll()
                    .Where(s => s.VolumeId == request.EntityId && !entityIds.Contains(s.Id));

                _childEntityRepository.BulkDelete(childEntities);
            }
        }
    }
}