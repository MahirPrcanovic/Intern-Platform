using InternshipPlatformAPI.Dtos.User;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Services.UsersService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Administrator")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<IdentityUser>>>> GetAllUsers()
        {
            return Ok(await this._userService.GetAllUsers());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteUser(string id)
        {
            return Ok(await this._userService.DeleteUser(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<string>>> AddNewUser(RegisterDto registerData)
        {
            return Ok(await this._userService.AddNewUser(registerData));
        }
    }
}
