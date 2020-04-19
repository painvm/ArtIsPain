using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Filters.BaseFilters;
using ArtIsPain.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Filters
{
    public class UpsertAlbumCommandFilter : UpsertEntityCommandFilter<UpsertAlbumCommand, MusicalAlbum>
    {
        public UpsertAlbumCommandFilter(IRepository<MusicalAlbum> albumRepository) : base(albumRepository)
        {
        }

        public override async Task CheckEntityExists(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is UpsertAlbumCommand);

            bool hasValidationPassed = true;

            if (param.Value != null)
            {
                UpsertAlbumCommand upsertAlbumCommand = param.Value as UpsertAlbumCommand;

                if (upsertAlbumCommand.Songs.Count == 0)
                {
                    hasValidationPassed = false;
                    context.Result = new NotFoundObjectResult("Album should contain at least one song.");
                }
            }

            if(hasValidationPassed)
            {
                await base.CheckEntityExists(context, next);
            }
        }
    }
}