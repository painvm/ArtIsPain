using ArtIsPain.Server.ViewModels.Album;
using MediatR;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.Commands.Album
{
    public class GetAlbumsByBandIdCommand : IRequest<ICollection<AlbumPreviewModel>>
    {
        public Guid BandId { get; set; }
    }
}