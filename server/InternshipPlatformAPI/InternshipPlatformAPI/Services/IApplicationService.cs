using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;

using Microsoft.AspNetCore.JsonPatch;

using Microsoft.AspNetCore.JsonPatch;

using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Services
{
    public interface IApplicationService
    {
        Task<ServiceResponse<ApplicationFormDto>> PostApplication(ApplicationFormDto applicationFormDto);
        Task<ServiceResponse<List<ApplicationDto>>> GetApplications(int page,int pageSize,string sortBy,string filter,string filterType);

        Task<ServiceResponse<Application>> GetSingleApplication(Guid id);
        Task<ServiceResponse<Application>> UpdateApplication(Guid id, ApplicationUpdateDto updateDto);
        Task<ServiceResponse<Comment>> AddApplicationComment(ApplicationCommentDto commentData, Guid id);


    }
}
