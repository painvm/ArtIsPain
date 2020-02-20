using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.Dtos.Album;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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