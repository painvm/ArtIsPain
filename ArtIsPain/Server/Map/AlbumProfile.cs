using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System;

namespace ArtIsPain.Server.Map
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<MusicalAlbum, AlbumPreviewModel>()
                .ForMember(dst => dst.ReleaseDate, opt => opt.MapFrom(src => src.CompletedDate))
                .ForMember(dst => dst.Band, opt => opt.MapFrom(src => src.Band));

            CreateMap<UpsertAlbumCommand, MusicalAlbum>()
                .ForMember(dst => dst.AuthorId, opt => opt.MapFrom(src => src.BandId))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.EntityId))
                .ForMember(dst => dst.StartDate, opt => opt.MapFrom(src => src.StartRecordDate.GetValueOrDefault()))
                .ForMember(dst => dst.CompletedDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dst => dst.Songs, opt => opt.MapFrom(src => src.Songs))
                .ForMember(dst => dst.AuthorId, opt => opt.MapFrom(src => src.BandId));

            CreateMap<MusicalAlbum, AlbumViewModel>()
                .ForMember(dst => dst.ReleaseDate, opt => opt.MapFrom(src => src.CompletedDate))
                .ForMember(dst => dst.StartRecordDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dst => dst.Band, opt => opt.MapFrom(src => src.Band));
        }
    }
}