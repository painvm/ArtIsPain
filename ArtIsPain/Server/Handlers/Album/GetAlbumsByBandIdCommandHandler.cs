using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Data.Repositories;
using ArtIsPain.Server.Dtos.Album;
using ArtIsPain.Server.Dtos.Band;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Album
{
    public class GetAlbumsByBandIdCommandHandler : IRequestHandler<GetAlbumsByBandIdCommand, AlbumResult>
    {
        private readonly IMapper _autoMapper;
        private readonly AlbumRepository _albumRepository;

        public GetAlbumsByBandIdCommandHandler(IMapper autoMapper, AlbumRepository albumRepository)
        {
            _autoMapper = autoMapper;
            _albumRepository = albumRepository;
        }

        public async Task<AlbumResult> Handle(GetAlbumsByBandIdCommand request, CancellationToken cancellationToken)
        {
            List<MusicalAlbum> albums = await _albumRepository.GetAlbumsByBandId(request.BandId)
                                                              .OrderBy(a => a.CompletedDate)
                                                              .ThenBy(a => a.Title).ToListAsync();

            return null;
        }
    }
}