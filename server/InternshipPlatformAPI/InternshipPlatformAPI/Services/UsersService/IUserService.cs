using InternshipPlatformAPI.Dtos.User;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace InternshipPlatformAPI.Services.UsersService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<IdentityUser>>> Get();
        Task<ServiceResponse<string>> Delete(string id);
        Task<ServiceResponse<string>> Post(RegisterDto registerData);
    }
}
