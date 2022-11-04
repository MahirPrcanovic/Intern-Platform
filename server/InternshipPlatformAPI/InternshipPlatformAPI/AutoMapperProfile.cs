using AutoMapper;
using InternshipPlatformAPI.Dtos.SelectionDto;
using InternshipPlatformAPI.Models;

namespace InternshipPlatformAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EditSelectionDto, Selection>();
            CreateMap<AddSelectionDto, Selection>();
            CreateMap<Selection, GetSelectionDto>();
        }
    }
}
