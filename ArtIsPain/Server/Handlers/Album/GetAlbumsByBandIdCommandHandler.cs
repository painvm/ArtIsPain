using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Album
{
    public class GetAlbumsByBandIdCommandHandler : IRequestHandler<GetAlbumsByBandIdCommand, AlbumViewModel>
    {
        private readonly IMapper _autoMapper;
        private readonly IAuthorizedRepository<MusicalAlbum> _albumRepository;

        public GetAlbumsByBandIdCommandHandler(IMapper autoMapper, IAuthorizedRepository<MusicalAlbum> albumRepository)
        {
            _autoMapper = autoMapper;
            _albumRepository = albumRepository;
        }

        public async Task<AlbumViewModel> Handle(GetAlbumsByBandIdCommand request, CancellationToken cancellationToken)
        {
            List<MusicalAlbum> albums = await _albumRepository.GetEntitiesByAuthorId(
                request.BandId, x => x.Include(y => y.Id)
                                      .Include(y => y.CompletedDate)
                                      .Include(y => y.Title)).ToListAsync();

            return null;
        }
    }
}