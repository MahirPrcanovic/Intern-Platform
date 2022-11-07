using AutoMapper;
using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Dtos.SelectionDto;

namespace InternshipPlatformAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<ApplicationFormDto, Application>();            
            CreateMap<EditSelectionDto, Selection>();
            CreateMap<AddSelectionDto, Selection>();
            CreateMap<Selection, GetSelectionDto>();
            CreateMap<Application,AddApplicantDto>();

        }
    }
}
