using AutoMapper;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Dtos.SelectionDto;
using InternshipPlatformAPI.Dtos.ApplicationDto;

namespace InternshipPlatformAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationFormDto, Application>();
            CreateMap<ApplicationDto, Application>();
            CreateMap<Application, ApplicationDto>();          
            CreateMap<EditSelectionDto, Selection>();
            CreateMap<AddSelectionDto, Selection>();
            CreateMap<Selection, GetSelectionDto>();
            CreateMap<Application,AddApplicantDto>();
            CreateMap<ApplicationCommentDto,Comment>();
            CreateMap<SelectionCommentDto,Comment>();
            
        }
    }
}
