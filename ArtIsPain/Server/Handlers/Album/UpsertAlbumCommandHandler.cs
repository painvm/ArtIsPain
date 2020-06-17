using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Shared.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Commands.Album;
using Server.ViewModels.Album.Song;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BandEntity = ArtIsPain.Shared.Models.Band;

namespace ArtIsPain.Server.Handlers.Album
{
    public class UpsertAlbumCommandHandler : BaseUpsertParentEntityHandler<MusicalAlbum, Song, UpsertAlbumCommand, SongPreviewModel, AlbumViewModel>
    {
        public UpsertAlbumCommandHandler(
            IMapper autoMapper,
            IRepository<MusicalAlbum> albumRepository,
            IRepository<Song> songRepository)
            : base(autoMapper, albumRepository, songRepository)
        {
        }

        protected override async Task<AlbumViewModel> Send(UpsertAlbumCommand request, CancellationToken cancellationToken)
        {
            Func<IQueryable<MusicalAlbum>, IQueryable<MusicalAlbum>> bandJoinQuery =
                x => x.Include(b => b.Band);

            AlbumViewModel result = await base.Send(request, x => x.Songs, cancellationToken, bandJoinQuery);

            return result;
        }
    }
}