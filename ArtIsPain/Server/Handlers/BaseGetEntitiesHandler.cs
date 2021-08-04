using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArtIsPain.Server.Commands;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels;
using ArtIsPain.Shared.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArtIsPain.Server.Handlers
{
    public abstract class BaseGetEntitiesHandler<TEntity, TRequest, TViewModel, TCollectionViewModel> : BaseHandler<TEntity, TRequest, TCollectionViewModel> where TCollectionViewModel : ICollectionViewModel<TViewModel>, new()
                                                                                                                             where TRequest : IGetEntitiesCommand<TViewModel, TCollectionViewModel>
                                                                                                                             where TEntity : class, IEntity
                                                                                                                             where TViewModel: IViewModel
    {
        private readonly IMapper _autoMapper;
        private readonly IRepository<TEntity> _entityRepository;

        public BaseGetEntitiesHandler(
            IMapper autoMapper,
            IRepository<TEntity> entityRepository)
        {
            _autoMapper = autoMapper;
            _entityRepository = entityRepository;
        }

        protected override async Task<TCollectionViewModel> Send(TRequest request, CancellationToken cancellationToken)
        {
            Func<IQueryable<TEntity>, IQueryable<TEntity>> searchConditionQuery = BuildSearchRequestQuery(request);

            IQueryable<TEntity> entities = 
                                _entityRepository.GetAll(searchConditionQuery);
            var results = _autoMapper.ProjectTo<TViewModel>(entities).ToListAsync();

            TCollectionViewModel collectionViewModel = new TCollectionViewModel
            {
                Data = await results
            };
            
            return collectionViewModel;
        }

        protected abstract Func<IQueryable<TEntity>, IQueryable<TEntity>> BuildSearchRequestQuery(TRequest request);

        protected override Task<TCollectionViewModel> Send(TRequest request, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            throw new NotImplementedException();
        }
    }
}