using ArtIsPain.Server.Dtos;
using ArtIsPain.Server.Dtos.Band;
using MediatR;
using System;

namespace ArtIsPain.Server.Commands
{
    public class GetBandByIdCommand : IGetEntityByIdCommand<BandViewModel>
    {
        public Guid EntityId { get; set; }
    }
}