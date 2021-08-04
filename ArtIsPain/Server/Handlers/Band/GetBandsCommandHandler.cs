namespace ArtIsPain.Server.Handlers.Band
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ArtIsPain.Server.Data.Interfaces;
    using ArtIsPain.Server.Handlers;
    using ArtIsPain.Shared.Models;
    using AutoMapper;
    using global::Server.Commands.Band;
    using global::Server.Extensions;
    using global::Server.ViewModels.Band;
    using Microsoft.EntityFrameworkCore;
    using Server.Commands.Band;
    using Server.ViewModels.Band;

    public class GetBandsCommandHandler : BaseGetEntitiesHandler<Band, GetBandsCommand, BandViewModel, BandCollectionViewModel>
    {
        private readonly IRepository<Song> _songRepository;
        private readonly IRepository<MusicalAlbum> _albumRepository;

        public GetBandsCommandHandler(
            IMapper autoMapper, 
            IRepository<Band> bandRepository,
            IRepository<Song> songRepository,
            IRepository<MusicalAlbum> albumRepository)
            : base(autoMapper, bandRepository)
        {
            _songRepository = songRepository;
            _albumRepository = albumRepository;
        }

        protected override Func<IQueryable<Band>, IQueryable<Band>> BuildSearchRequestQuery(GetBandsCommand request)
        {
            if(string.IsNullOrEmpty(request.SearchTerm) || string.IsNullOrWhiteSpace(request.SearchTerm)){
                return null;
            }

            List<Guid> matchedBySongTitleAlbumIdList = _songRepository.GetAll(
                songs => songs.Where(
                    song => EF.Functions.Like(song.Title, $"%{request.SearchTerm}%")))
                    .Select(song => song.Album.Id).ToList();

            List<Guid> matchedByAlbumContentBandIdList = _albumRepository.GetAll(
                albums => albums.Where(
                    album => EF.Functions.Like(album.Title, $"%{request.SearchTerm}%")
                    || matchedBySongTitleAlbumIdList.Contains(album.Id)))
                    .Select(album => album.Band.Id).ToList();

            Func<IQueryable<Band>, IQueryable<Band>> bandsQuery = bands => bands.Where(
                band => EF.Functions.Like(band.Title, $"%{request.SearchTerm}%")
                || matchedByAlbumContentBandIdList.Contains(band.Id));

            return bandsQuery;
        }

        protected override async Task<BandCollectionViewModel> Send(GetBandsCommand request, CancellationToken cancellationToken)
        {
            BandCollectionViewModel result = await base.Send(request, cancellationToken);

            return result;
        }

       
    }
}