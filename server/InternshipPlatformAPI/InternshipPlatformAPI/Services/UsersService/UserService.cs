using EllipticCurve;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos.User;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Services.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace InternshipPlatformAPI.Services.UsersService
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(DataContext dataContext,UserManager<IdentityUser> userManager,IEmailService emailService,IHttpContextAccessor httpContextAccessor)
        {
            this._dataContext = dataContext;
            this._userManager = userManager;
            this._emailService = emailService;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<string>> AddNewUser(RegisterDto registerData)
        {
            var user = new IdentityUser { UserName = registerData.UserName };
            var result = await this._userManager.CreateAsync(user, registerData.Password);
            var serviceResponse = new ServiceResponse<string>();
            if (result.Succeeded)
            {
                serviceResponse.Data = user.Id;
                serviceResponse.Message = "Successfull register";
                this._dataContext.UserRoles.Add(new IdentityUserRole<string>
                {
                    RoleId = "413743e0-asd2–42fe-afbf-59kmccmk72cd6",
                    UserId = user.Id
                });
                await this._dataContext.SaveChangesAsync();
                var message = "UserName: " + registerData.UserName + " Password: " + registerData.Password;
                await this._emailService.SendEmailAsync(registerData.Email, "Internship platform login",message);
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
            if (user == null)
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
            //DO NOT INCLUDE ADMIN!
            users.RemoveAll(el => el.Id == "02174cf0–9412–4cfe - afbf - 59f706d72cf6");

            serviceResponse.Data = users;

            return serviceResponse;
            
        }
    }
}
