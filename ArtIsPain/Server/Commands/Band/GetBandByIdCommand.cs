using ArtIsPain.Server.Dtos;
using ArtIsPain.Server.Dtos.Band;
using MediatR;
using System;

namespace ArtIsPain.Server.Commands
{
    public class GetBandByIdCommand : IRequest<BandResult>
    {
        public Guid BandId { get; set; }
    }
}