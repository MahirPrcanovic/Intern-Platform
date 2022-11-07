using InternshipPlatformAPI.Models;

namespace InternshipPlatformAPI.Services
{
    public interface ILoginService
    {
        Task<ServiceResponse<string>> Login(string username, string password,bool rememberMe);
        Task<ServiceResponse<string>> Register(string username, string password,bool rememberMe);
    }
}
