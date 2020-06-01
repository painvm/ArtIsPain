using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Server.ViewModels.Album.Song;
using System.Collections.Generic;
using System;

namespace ArtIsPain.Server.Handlers.Album
{
    public class GetAlbumByIdCommandHandler : BaseGetEntityByIdHandler<MusicalAlbum, GetAlbumByIdCommand, AlbumViewModel>
    {
        public GetAlbumByIdCommandHandler(IMapper autoMapper, IRepository<MusicalAlbum> entityRepository) : base(autoMapper, entityRepository)
        {
        }

        protected override async Task<AlbumViewModel> Send(GetAlbumByIdCommand request, CancellationToken cancellationToken)
        {
            AlbumViewModel album = await base.Send(request, cancellationToken, null);
            album.Songs = album.Songs.OrderBy(x => x.Order).ToList();

            return album;
        }
    }
}