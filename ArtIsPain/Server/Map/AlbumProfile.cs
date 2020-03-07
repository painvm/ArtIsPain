using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Shared.Models;
using AutoMapper;

namespace ArtIsPain.Server.Map
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<MusicalAlbum, AlbumPreviewModel>()
                .ForMember(dst => dst.ReleaseDate, opt => opt.MapFrom(src => src.CompletedDate));

            CreateMap<UpsertAlbumCommand, AlbumViewModel>();
        }
    }
}