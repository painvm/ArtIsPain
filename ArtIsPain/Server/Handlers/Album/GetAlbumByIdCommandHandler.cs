using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Album
{
    public class GetAlbumByIdCommandHandler : BaseGetEntityByIdHandler<MusicalAlbum, GetAlbumByIdCommand, AlbumViewModel>
    {
        public GetAlbumByIdCommandHandler(IMapper autoMapper, IRepository<MusicalAlbum> entityRepository) : base(autoMapper, entityRepository)
        {
        }

        protected override async Task<AlbumViewModel> Send(GetAlbumByIdCommand request, CancellationToken cancellationToken)
        {
            return await base.Send(request, cancellationToken, null);
        }
    }
}