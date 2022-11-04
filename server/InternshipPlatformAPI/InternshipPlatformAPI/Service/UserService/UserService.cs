using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.ModelDtos;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InternshipPlatformAPI.Service.UserService
{
    public class UserService : IUserService
    {
     
        private IConfiguration _configuration;
        private UserManager<IdentityUser> _userManager = null;
        private SignInManager<IdentityUser> _signInManager = null;

        public UserService(IConfiguration configuration, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public async Task<ServiceResponse<string>> LoginUserAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if(user == null)
            {
                return new ServiceResponse<string>
                {
                    Message = "There is no user with that username.",
                    Success = false
                };
            }

            var result = await _userManager.CheckPasswordAsync(user,password);
            if (result == false)
                return new ServiceResponse<string>
                {
                    Message = "Invalid password",
                    Success = false
                };

            var claims = new[]
            {
                new Claim("Username", username),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:  new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new ServiceResponse<string>
            {
                Data = tokenAsString,
                Message = "Succesfully logged in.",
                Success = true,
                ExpireDate = token.ValidTo
            };




        }


    }
}
