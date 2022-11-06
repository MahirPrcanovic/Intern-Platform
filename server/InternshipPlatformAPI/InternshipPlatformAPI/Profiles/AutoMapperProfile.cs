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
<<<<<<< HEAD
            CreateMap<ApplicationFormDto, Application>();
            CreateMap<ApplicationDto, Application>();
            CreateMap<Application, ApplicationDto>();
=======
            CreateMap<ApplicationFormDto, Application>();            
            CreateMap<EditSelectionDto, Selection>();
            CreateMap<AddSelectionDto, Selection>();
            CreateMap<Selection, GetSelectionDto>();
            CreateMap<Application,AddApplicantDto>();
>>>>>>> d5982ed321869349eeb7721e47358c94ba42d026
        }
    }
}
