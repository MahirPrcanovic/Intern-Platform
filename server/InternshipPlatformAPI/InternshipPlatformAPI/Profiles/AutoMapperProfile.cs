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
            CreateMap<ApplicationDto, Application>();
            CreateMap<Application, ApplicationDto>();
            CreateMap<ApplicationFormDto, Application>();            
            CreateMap<EditSelectionDto, Selection>();
            CreateMap<AddSelectionDto, Selection>();
            CreateMap<Selection, GetSelectionDto>();
            CreateMap<Application,AddApplicantDto>();
<<<<<<< HEAD
            CreateMap<ApplicationCommentDto,Comment>();
         
=======
>>>>>>> e7519704f7340dfcda000f239e641eda8d6bafaf
        }
    }
}
