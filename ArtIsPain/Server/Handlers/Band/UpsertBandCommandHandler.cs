using ArtIsPain.Server.Commands.Band;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Dtos.Band;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BandModel = ArtIsPain.Shared.Models.Band;

namespace ArtIsPain.Server.Handlers.Band
{
    public class UpsertBandCommandHandler : BaseUpsertEntityCommandHandler<BandModel, UpsertBandCommand, BandResult>
    {
        public UpsertBandCommandHandler(IMapper autoMapper, IRepository<BandModel> albumRepository)
            : base(autoMapper, albumRepository)
        {
        }

        public override async Task<BandResult> Handle(UpsertBandCommand request, CancellationToken cancellationToken)
        {
            BandResult result = await base.Handle(request, cancellationToken);

            return result;
        }
    }
}