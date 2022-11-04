using AutoMapper;
using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;

namespace InternshipPlatformAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationFormDto, Application>();
        }
    }
}
