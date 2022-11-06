using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<ServiceResponse<string>>> login(LoginDto loginData)
        {
            return Ok(await this._loginService.Login(loginData.UserName, loginData.Password,loginData.rememberMe));
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<string>>> register(LoginDto registerData)
        {
            return Ok(await this._loginService.Register(registerData.UserName, registerData.Password,registerData.rememberMe));
        }
    }
}
