using ArtIsPain.Server.Dtos;
using ArtIsPain.Server.Dtos.Band;
using MediatR;
using System;

namespace ArtIsPain.Server.Commands
{
    public class GetBandByIdCommand : IGetEntityByIdCommand<BandResult>
    {
        public Guid EntityId { get; set; }
    }
}