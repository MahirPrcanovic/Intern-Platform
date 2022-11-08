using InternshipPlatformAPI.Models;

namespace InternshipPlatformAPI.Services
{
    public interface ILoginService
    {
        Task<bool> Login(string username, string password,bool rememberMe);
        Task<string> CreateToken();
    }
}
