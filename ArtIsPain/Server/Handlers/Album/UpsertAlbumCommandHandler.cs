using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Data.Repositories;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Server.ViewModels.Band;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using BandEntity = ArtIsPain.Shared.Models.Band;

namespace ArtIsPain.Server.Handlers.Album
{
    public class UpsertAlbumCommandHandler : BaseUpsertEntityCommandHandler<MusicalAlbum, UpsertAlbumCommand, AlbumViewModel>
    {
        private readonly IRepository<BandEntity> _bandRepository;

        public UpsertAlbumCommandHandler(
            IMapper autoMapper,
            IRepository<MusicalAlbum> albumRepository,
            IRepository<BandEntity> bandRepository)
            : base(autoMapper, albumRepository)
        {
            _bandRepository = bandRepository;
        }

        public override async Task<AlbumViewModel> Handle(UpsertAlbumCommand request, CancellationToken cancellationToken)
        {
            AlbumViewModel result = await base.Handle(request, cancellationToken);
            BandEntity band = await _bandRepository.GetById(request.BandId);

            result.Band = _autoMapper.Map<BandPreviewModel>(band);

            return result;
        }
    }
}