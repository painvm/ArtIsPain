using ArtIsPain.Server.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Filters.BaseFilters
{
    public abstract class EntityCommandValidator<TRequest, TEntity> : IAsyncActionFilter where TRequest : IRequest<IViewModel>
                                                                                        where TEntity : class
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await CheckEntityExists(context);
        }

        public abstract Task CheckEntityExists(ActionExecutingContext context);
    }
}