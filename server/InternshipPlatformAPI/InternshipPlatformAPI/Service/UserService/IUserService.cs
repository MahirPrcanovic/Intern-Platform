using InternshipPlatformAPI.ModelDtos;
using InternshipPlatformAPI.Models;

namespace InternshipPlatformAPI.Service.UserService
{
    public interface IUserService 
    {
        public Task<ServiceResponse<string>> LoginUserAsync(string username,string password);
    }
}
