using ArtIsPain.Shared.Models;
using AutoMapper;
using Server.Commands.Album;
using Server.ViewModels.Album.Song;

namespace Server.Map
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<SongPreviewModel, Song>()
                .ForMember(dst => dst.VolumeId, opt => opt.MapFrom(src => src.AlbumId))
                .ReverseMap();

            CreateMap<UpsertSongCommand, Song>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.EntityId))
                .ForMember(dst => dst.VolumeId, opt => opt.MapFrom(src => src.AlbumId));
        }
    }
}