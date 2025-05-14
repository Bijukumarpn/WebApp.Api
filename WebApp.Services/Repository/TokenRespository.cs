using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp.Entity.Dto;

namespace WebApp.Services.Repository
{
    public class TokenRespository : ITokenRepository
    {
        private readonly IConfiguration _configuration;

        public TokenRespository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GenerateToken(UserInfoRequest userInfo)
        {
                //create claims details based on the user information
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", "123"),
                        new Claim("DisplayName", "UserName"),
                        new Claim("UserName", userInfo.UserName ?? ""),
                        new Claim("Email", "test@email.com")
                    };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    null,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signIn);

                return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
