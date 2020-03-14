using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Server.ViewModels.Writer;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Map
{
    public class WriterProfile : Profile
    {
        public WriterProfile()
        {
            CreateMap<Writer, WriterViewModel>()
                .ForMember(dst => dst.PoetryVolumes, opt => opt.MapFrom(src => src.PoetryVolumeAuthorships));

            CreateMap<PoetryVolumeAuthorship, WriterPreview>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Author.Title));
        }
    }
}