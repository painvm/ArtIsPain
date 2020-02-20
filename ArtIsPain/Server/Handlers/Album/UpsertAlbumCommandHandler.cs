using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Repositories;
using ArtIsPain.Server.Dtos.Album;
using ArtIsPain.Server.Handlers.Band;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Album
{
    public class UpsertAlbumCommandHandler : BaseUpsertEntityCommandHandler<MusicalAlbum, UpsertAlbumCommand, AlbumViewModel>
    {
        public UpsertAlbumCommandHandler(IMapper autoMapper, AlbumRepository albumRepository)
            : base(autoMapper, albumRepository)
        {
        }

        public override async Task<AlbumViewModel> Handle(UpsertAlbumCommand request, CancellationToken cancellationToken)
        {
            AlbumViewModel result = await base.Handle(request, cancellationToken);

            return result;
        }
    }
}