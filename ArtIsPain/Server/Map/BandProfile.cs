using ArtIsPain.Server.Dtos;
using ArtIsPain.Shared.Models;
using AutoMapper;

namespace ArtIsPain.Server.Map
{
    public class BandProfile : Profile
    {
        public BandProfile()
        {
            CreateMap<Band, BandDto>()
                 .ForMember(dst => dst.FormationDate, opt => opt.MapFrom(src => src.StartActivityDate))
                 .ForMember(dst => dst.DisbandDate, opt => opt.MapFrom(src => src.EndActivityDate))
                 .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Title));
        }
    }
}