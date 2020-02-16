using ArtIsPain.Server.Dtos.Album;
using MediatR;
using System;

namespace ArtIsPain.Server.Commands.Album
{
    public class GetAlbumsByBandIdCommand : IRequest<AlbumResult>
    {
        public Guid BandId { get; set; }
    }
}