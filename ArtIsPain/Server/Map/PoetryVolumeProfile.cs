using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Server.ViewModels.Writer;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System.Linq;

namespace ArtIsPain.Server.Map
{
    public class PoetryVolumeProfile : Profile
    {
        public PoetryVolumeProfile()
        {
            CreateMap<Writer, WriterPreview>();

            CreateMap<PoetryVolumeAuthorship, PoetryVolumeViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.EntityId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.PoetryVolume.Description))
                .ForMember(dst => dst.StartDate, opt => opt.MapFrom(src => src.PoetryVolume.StartDate))
                .ForMember(dst => dst.PublicationDate, opt => opt.MapFrom(src => src.PoetryVolume.CompletedDate))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.PoetryVolume.Title));

            CreateMap<PoetryVolumeAuthorship, PoetryVolumePreviewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.PoetryVolume.Id))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.PoetryVolume.Title))
                .ForMember(dst => dst.PublicationDate, opt => opt.MapFrom(src => src.PoetryVolume.CompletedDate));

            CreateMap<UpsertPoetryVolumeCommand, PoetryVolume>()
                .ForMember(dst => dst.CompletedDate, opt => opt.MapFrom(src => src.PublicationDate))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.EntityId));

            CreateMap<PoetryVolume, PoetryVolumeViewModel>()
                .ForMember(dst => dst.PublicationDate, opt => opt.MapFrom(src => src.CompletedDate));

            CreateMap<PoetryVolume, PoetryVolumePreviewModel>()
                .ForMember(dst => dst.Authors, opt => opt.MapFrom(src => src.PoetryVolumeAuthorships));

            CreateMap<PoetryVolumeAuthorship, WriterPreview>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Author.Title));
        }
    }
}