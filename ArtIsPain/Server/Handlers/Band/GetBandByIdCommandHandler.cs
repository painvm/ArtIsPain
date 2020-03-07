using ArtIsPain.Server.Commands.Band;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Band;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using BandModel = ArtIsPain.Shared.Models.Band;

namespace ArtIsPain.Server.Handlers.Band
{
    public class GetBandByIdCommandHandler : BaseGetEntityByIdHandler<BandModel, GetBandByIdCommand, BandViewModel>
    {
        public GetBandByIdCommandHandler(IMapper autoMapper, IRepository<BandModel> bandRepository)
            : base(autoMapper, bandRepository)
        {
        }

        public override async Task<BandViewModel> Handle(GetBandByIdCommand request, CancellationToken cancellationToken)
        {
            BandViewModel bandToReturn = await base.Handle(request, cancellationToken);

            return bandToReturn;
        }
    }
}