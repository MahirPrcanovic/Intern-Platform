using InternshipPlatformAPI.Dtos.User;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Services.LoginService;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Controllers
{
    [Route("auth")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            this._loginService = loginService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login(LoginDto loginData)
        {
            return !await this._loginService.Login(loginData.UserName, loginData.Password, loginData.rememberMe) ? NotFound(new ServiceResponse<string>() { Success=false,Message="Incorrect login info."}) : Ok(new { Token = await this._loginService.CreateToken() , userName = loginData.UserName});
        }   
    }
}
