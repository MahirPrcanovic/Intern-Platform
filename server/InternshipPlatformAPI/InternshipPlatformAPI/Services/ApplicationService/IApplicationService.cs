using InternshipPlatformAPI.Dtos.ApplicationDto;
using InternshipPlatformAPI.Models;

using Microsoft.AspNetCore.JsonPatch;

using Microsoft.AspNetCore.JsonPatch;

using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Services.ApplicationService
{
    public interface IApplicationService
    {
        Task<ServiceResponse<ApplicationFormDto>> Post(ApplicationFormDto applicationFormDto);
        Task<ServiceResponse<List<ApplicationDto>>> Get(int page, int pageSize, string sortBy, string filter, string filterType);

        Task<ServiceResponse<Application>> Get(Guid id);
        Task<ServiceResponse<Application>> Update(Guid id, ApplicationUpdateDto updateDto);
        Task<ServiceResponse<Comment>> PostComment(ApplicationCommentDto commentData, Guid id);


    }
}
