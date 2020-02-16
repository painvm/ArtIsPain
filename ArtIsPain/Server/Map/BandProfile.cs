﻿using ArtIsPain.Server.Dtos;
using ArtIsPain.Server.Dtos.Band;
using ArtIsPain.Shared.Models;
using ArtIsPain.Server.Commands.Band;
using AutoMapper;
using System;

namespace ArtIsPain.Server.Map
{
    public class BandProfile : Profile
    {
        public BandProfile()
        {
            CreateMap<Band, BandResult>()
                 .ForMember(dst => dst.FormationDate, opt => opt.MapFrom(src => src.StartActivityDate))
                 .ForMember(dst => dst.DisbandDate, opt => opt.MapFrom(src => src.EndActivityDate))
                 .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Title));

            CreateMap<UpsertBandCommand, Band>()
                 .ForMember(dst => dst.StartActivityDate, opt => opt.MapFrom(src => src.FormationDate))
                 .ForMember(dst => dst.EndActivityDate, opt => opt.MapFrom(src => src.DisbandDate))
                 .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dst => dst.Id, opt => opt.NullSubstitute(Guid.NewGuid()));
        }
    }
}