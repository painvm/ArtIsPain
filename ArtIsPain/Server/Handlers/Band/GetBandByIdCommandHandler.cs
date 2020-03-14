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
    public class GetBandByIdCommandHandler : BaseGetEntityByIdHandler<BandModel, GetBandByIdCommand, BandViewModel>
    {
        public GetBandByIdCommandHandler(IMapper autoMapper, IRepository<BandModel> bandRepository)
            : base(autoMapper, bandRepository)
        {
        }

        protected override async Task<BandViewModel> Send(GetBandByIdCommand request, CancellationToken cancellationToken)
        {
            BandViewModel bandToReturn = await base.Send(request, cancellationToken, null);

            return bandToReturn;
        }
    }
}