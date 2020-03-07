using ArtIsPain.Server.Commands.Band;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Band;
using AutoMapper;
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

        public override async Task<BandViewModel> Handle(UpsertBandCommand request, CancellationToken cancellationToken)
        {
            BandViewModel result = await base.Handle(request, cancellationToken);

            return result;
        }
    }
}