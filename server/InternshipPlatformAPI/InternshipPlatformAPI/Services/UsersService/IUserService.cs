using InternshipPlatformAPI.Dtos.User;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace InternshipPlatformAPI.Services.UsersService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<IdentityUser>>> GetAllUsers();
        Task<ServiceResponse<string>> DeleteUser(string id);
        Task<ServiceResponse<string>> AddNewUser(RegisterDto registerData);
    }
}
