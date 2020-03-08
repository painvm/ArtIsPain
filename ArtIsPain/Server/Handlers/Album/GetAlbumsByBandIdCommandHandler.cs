using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Album
{
    public class GetAlbumsByBandIdCommandHandler : IRequestHandler<GetAlbumsByBandIdCommand, ICollection<AlbumPreviewModel>>
    {
        private readonly IMapper _autoMapper;
        private readonly IAuthorizedRepository<MusicalAlbum> _albumRepository;

        public GetAlbumsByBandIdCommandHandler(IMapper autoMapper, IAuthorizedRepository<MusicalAlbum> albumRepository)
        {
            _autoMapper = autoMapper;
            _albumRepository = albumRepository;
        }

        public async Task<ICollection<AlbumPreviewModel>> Handle(GetAlbumsByBandIdCommand request, CancellationToken cancellationToken)
        {
            IQueryable<MusicalAlbum> albums = _albumRepository.GetEntitiesByAuthorId(
                request.BandId, x => x.Include(a => a.Band));

            List<AlbumPreviewModel> responseObjects = await _autoMapper.ProjectTo<AlbumPreviewModel>(albums).ToListAsync();

            return responseObjects;
        }
    }
}