using ArtIsPain.Server.Commands;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels;
using ArtIsPain.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Filters.BaseFilters
{
    public class UpsertEntityCommandFilter<TRequest, TEntity> : EntityCommandFilter<TRequest, TEntity>
                                                                   where TRequest : class, IUpsertEntityCommand<IViewModel>
                                                                   where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _entityRepository;

        public UpsertEntityCommandFilter(IRepository<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public override async Task CheckEntityExists(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is TRequest);
            if (param.Value != null)
            {
                if (param.Value is TRequest upsertBandCommand && upsertBandCommand.EntityId.HasValue)
                {
                    if (await _entityRepository.GetById(upsertBandCommand.EntityId.Value).FirstOrDefaultAsync() == null)
                    {
                        context.Result = new NotFoundObjectResult("Object is not found !!!");
                    }
                    else
                    {
                        await next();
                    }
                }
                else
                {
                    await next();
                }
            }
            else
            {
                await next();
            }
        }
    }
}