using ArtIsPain.Server.Commands.Band;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Band;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BandModel = ArtIsPain.Shared.Models.Band;

namespace ArtIsPain.Server.Handlers.Band
{
    public class UpsertBandCommandHandler : BaseUpsertEntityCommandHandler<BandModel, UpsertBandCommand, BandViewModel>
    {
        public UpsertBandCommandHandler(IMapper autoMapper, IRepository<BandModel> albumRepository)
            : base(autoMapper, albumRepository)
        {
        }

        protected override async Task<BandViewModel> Send(UpsertBandCommand request, CancellationToken cancellationToken)
        {
            Func<IQueryable<BandModel>, IQueryable<BandModel>> albumJoinQuery =
                x => x.Include(b => b.Albums);

            BandViewModel result = await base.Send(request, cancellationToken, albumJoinQuery);

            return result;
        }
    }
}