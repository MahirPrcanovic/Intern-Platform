using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos.User;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InternshipPlatformAPI.Services.UsersService
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(DataContext dataContext,UserManager<IdentityUser> userManager)
        {
            this._dataContext = dataContext;
            this._userManager = userManager;
        }

        public async Task<ServiceResponse<string>> AddNewUser(RegisterDto registerData)
        {
            var user = new IdentityUser { UserName = registerData.UserName };
            var result = await this._userManager.CreateAsync(user, registerData.Password);
            var serviceResponse = new ServiceResponse<string>();
            if (result.Succeeded)
            {
                serviceResponse.Message = "Successfull register";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not successfull";
            }
            //SEND EMAIL TO registerData.email
            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> DeleteUser(string id)
        {
            var serviceResponse = new ServiceResponse<string>();
            var user = await this._userManager.FindByIdAsync(id);
            if(user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
                return serviceResponse;
            }
            var result = await this._userManager.DeleteAsync(user);
            //await this.
            if (result.Succeeded)
            {
                serviceResponse.Message = "Deletion successfull.";
                return serviceResponse;
            }
            serviceResponse.Success = false;
            serviceResponse.Message = "User deletion not successfull.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<IdentityUser>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<IdentityUser>>();
            var users = await this._dataContext.Users.ToListAsync();
            serviceResponse.Data = users;

            return serviceResponse;
            
        }
    }
}
