using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;

namespace InternshipPlatformAPI.Services
{
    public interface IApplicationService
    {
        Task<ServiceResponse<ApplicationFormDto>> PostApplication(ApplicationFormDto applicationFormDto);
    }
}
