using ArtIsPain.Server.Dtos.Album;
using MediatR;
using System;

namespace ArtIsPain.Server.Commands.Album
{
    public class GetAlbumsByBandIdCommand : IRequest<AlbumViewModel>
    {
        public Guid BandId { get; set; }
    }
}