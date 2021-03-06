﻿using AutoMapper;
using HosteliteAPI.Dtos;
using HosteliteAPI.Helpers;
using HosteliteAPI.Models;
using System.Linq;

namespace HosteliteAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserForListDto>().ForMember(dest => dest.PhotoUrl,
                option => option.MapFrom(src => src.Photos.FirstOrDefault(p=> p.IsMain).Url))
                .ForMember(dest => dest.Age, option => option.MapFrom(src => src.DOB.CalculateAge()));
               

            CreateMap<User, UserForDetailedDtos>().ForMember(dest => dest.PhotoUrl,
                option => option.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                 .ForMember(dest => dest.Age, option => option.MapFrom(src => src.DOB.CalculateAge()));

            CreateMap<Hostel, HostelsForDetailedDto>();

            CreateMap<Hostel, HostelForListDto>();

            CreateMap<Photo, PhotosForDetailedDto>();

            CreateMap<UserForRegisterDto, User>();

            CreateMap<HostelPhoto, HostelPhotosForDetailedDto>();
    }
    }
}