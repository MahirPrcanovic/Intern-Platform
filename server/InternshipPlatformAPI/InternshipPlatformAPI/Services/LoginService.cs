using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InternshipPlatformAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private IdentityUser? _user;
        public LoginService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._configuration = configuration;
        }
        public async Task<bool> Login(string username, string password,bool rememberMe=true)
        {
            //ServiceResponse<string>
            _user = await _userManager.FindByNameAsync(username);
            var serviceResponse = new ServiceResponse<LoginResponseDto>();
            //var result = await this._signInManager.PasswordSignInAsync(username, password, rememberMe, false);
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, password);
            //if (result.Succeeded)
            //{
            //    var user = await this._userManager.FindByNameAsync(username);
            //    serviceResponse.Success = true;
            //    serviceResponse.Message = "login Successfull!";
            //    var userT = new User() { Id = user.Id,Name = user.UserName };
            //    //serviceResponse.Data = CreateToken(userT);
            //    serviceResponse.Data = user.Id;
            //    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
            //}
            //else
            //{
            //    serviceResponse.Success = false;
            //    serviceResponse.Message = "login not successfull!";
            //}
            //serviceResponse.Data = result.ToString();
            return result;
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
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            //List<Claim> claims = new List<Claim>{
            //    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            //    new Claim(ClaimTypes.Name,user.Name)
            //};
            //SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(this._configuration.GetSection("AppSettings:Token").Value));

            //SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(claims),
            //    Expires = DateTime.Now.AddDays(1),
            //    SigningCredentials = creds
            //};
            //JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);
        }
        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName),
            new Claim(ClaimTypes.NameIdentifier,_user.Id)
        };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
