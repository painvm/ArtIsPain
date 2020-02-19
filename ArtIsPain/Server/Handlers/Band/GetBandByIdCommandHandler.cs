using ArtIsPain.Server.Commands;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Dtos;
using ArtIsPain.Server.Data.Repositories;
using ArtIsPain.Server.Dtos.Band;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BandModel = ArtIsPain.Shared.Models.Band;
using System.Linq;

namespace ArtIsPain.Server.Handlers.Band
{
    public class GetBandByIdCommandHandler : BaseGetEntityByIdHandler<BandModel, GetBandByIdCommand, BandResult>
    {
        public GetBandByIdCommandHandler(IMapper autoMapper, IRepository<BandModel> bandRepository)
            : base(autoMapper, bandRepository)
        {
        }

        public override async Task<BandResult> Handle(GetBandByIdCommand request, CancellationToken cancellationToken)
        {
            BandResult bandToReturn = await base.Handle(request, cancellationToken);

            return bandToReturn;
        }
    }
}