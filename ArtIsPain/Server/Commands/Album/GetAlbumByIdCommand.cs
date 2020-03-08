using ArtIsPain.Server.ViewModels.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Commands.Album
{
    public class GetAlbumByIdCommand : IGetEntityByIdCommand<AlbumViewModel>
    {
        public Guid EntityId { get; set; }
    }
}