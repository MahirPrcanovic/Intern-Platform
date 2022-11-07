using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
<<<<<<< HEAD
using Microsoft.AspNetCore.JsonPatch;
=======
>>>>>>> e7519704f7340dfcda000f239e641eda8d6bafaf
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Services
{
    public interface IApplicationService
    {
        Task<ServiceResponse<ApplicationFormDto>> PostApplication(ApplicationFormDto applicationFormDto);
        Task<ServiceResponse<List<ApplicationDto>>> GetApplications(int page,int pageSize,string sortBy,string filter,string filterType);
<<<<<<< HEAD
        Task<ServiceResponse<Application>> GetSingleApplication(Guid id);
        Task<ServiceResponse<Application>> UpdateApplication(Guid id, ApplicationUpdateDto updateDto);
        Task<ServiceResponse<Comment>> AddApplicationComment(ApplicationCommentDto commentData);
=======
        //Task<ServiceResponse<Comment>> PostComment();
>>>>>>> e7519704f7340dfcda000f239e641eda8d6bafaf
    }
}
