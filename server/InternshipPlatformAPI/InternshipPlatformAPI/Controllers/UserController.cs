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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._userService.Get());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await this._userService.Delete(id));
        }
        [HttpPost("addNewUser")]
        public async Task<IActionResult> Post(RegisterDto registerData)
        {
            return Ok(await this._userService.Post(registerData));
        }
    }
}
