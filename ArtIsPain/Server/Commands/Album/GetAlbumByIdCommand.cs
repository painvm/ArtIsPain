using ArtIsPain.Server.ViewModels.Album;
using System;

namespace ArtIsPain.Server.Commands.Album
{
    public class GetAlbumByIdCommand : IGetEntityByIdCommand<AlbumViewModel>
    {
        public Guid EntityId { get; set; }
    }
}