using ArtIsPain.Server.Dtos;
using MediatR;
using System;

namespace ArtIsPain.Server.Commands
{
    public class GetBandByIdCommand : IRequest<BandDto>
    {
        public Guid BandId { get; set; }
    }
}