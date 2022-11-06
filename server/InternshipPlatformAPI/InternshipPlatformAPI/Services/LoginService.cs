using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InternshipPlatformAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public LoginService(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager,IConfiguration configuration)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._configuration = configuration;
        }
        public async Task<ServiceResponse<string>> Login(string username, string password,bool rememberMe)
        {
            var serviceResponse = new ServiceResponse<string>();
            var result = await this._signInManager.PasswordSignInAsync(username, password, rememberMe, false);
            if (result.Succeeded)
            {
                var user = await this._userManager.FindByNameAsync(username);
                serviceResponse.Success = true;
                serviceResponse.Message = "login Successfull!";
                var userT = new User() { Id = user.Id,Name = user.UserName };
                //serviceResponse.Data = CreateToken(userT);
                serviceResponse.Data = user.Id;
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "login not successfull!";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> Register(string username, string password, bool rememberMe)
        {
            var user = new IdentityUser { UserName = username };
            var result = await this._userManager.CreateAsync(user, password);
            var serviceResponse = new ServiceResponse<string>();
            if (result.Succeeded)
            {
                serviceResponse.Message = "successfull register";
            }
            else
            {
                serviceResponse.Message = "Not successfull";
            }
            return serviceResponse;
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(this._configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
