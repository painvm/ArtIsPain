using ArtIsPain.Server.ViewModels;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers
{
    public abstract class BaseHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TResponse : IResponse
                                                                                                                        where TRequest : IRequest<TResponse>
                                                                                                                        where TEntity : class
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return Send(request, cancellationToken);
        }

        protected abstract Task<TResponse> Send(TRequest request, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null);

        protected abstract Task<TResponse> Send(TRequest request, CancellationToken cancellationToken);
    }
}