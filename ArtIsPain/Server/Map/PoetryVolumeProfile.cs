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
    public class PoetryVolumeProfile : Profile
    {
        public PoetryVolumeProfile()
        {
            CreateMap<Writer, WriterPreview>();

            CreateMap<PoetryVolumeAuthorship, PoetryVolumeViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.PoetryVolumeId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.PoetryVolume.Description))
                .ForMember(dst => dst.StartDate, opt => opt.MapFrom(src => src.PoetryVolume.StartDate))
                .ForMember(dst => dst.PublicationDate, opt => opt.MapFrom(src => src.PoetryVolume.CompletedDate))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.PoetryVolume.Title))
        }
    }
}