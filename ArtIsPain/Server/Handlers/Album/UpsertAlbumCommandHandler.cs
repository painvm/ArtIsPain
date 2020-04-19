using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using BandEntity = ArtIsPain.Shared.Models.Band;

namespace ArtIsPain.Server.Handlers.Album
{
    public class UpsertAlbumCommandHandler : BaseUpsertEntityCommandHandler<MusicalAlbum, UpsertAlbumCommand, AlbumViewModel>
    {
        public UpsertAlbumCommandHandler(
            IMapper autoMapper,
            IRepository<MusicalAlbum> albumRepository,
            IRepository<BandEntity> bandRepository)
            : base(autoMapper, albumRepository)
        {
        }

        protected override async Task<AlbumViewModel> Send(UpsertAlbumCommand request, CancellationToken cancellationToken)
        {
            AlbumViewModel result = await base.Send(request, cancellationToken, null);

            return result;
        }
    }
}