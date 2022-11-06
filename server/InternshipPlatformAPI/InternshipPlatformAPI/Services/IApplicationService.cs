using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Services
{
    public interface IApplicationService
    {
        Task<ServiceResponse<ApplicationFormDto>> PostApplication(ApplicationFormDto applicationFormDto);
        Task<ServiceResponse<List<ApplicationDto>>> GetApplications(int page,int pageSize,string sortBy,string filter);
        //Task<ServiceResponse<Comment>> PostComment();
    }
}
