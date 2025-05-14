using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Entity.Dto;
using WebApp.Services.Repository;

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository _tokenRepository;

        public AccountController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this._tokenRepository = tokenRepository;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(UserInfoRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid Credentials");
            }

            var user = await userManager.FindByNameAsync(request.UserName);

            var result = await userManager.CheckPasswordAsync(user, request.Pasword);

            if(result)
            {
                string token = await _tokenRepository.GenerateToken(request);
                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Invalid Credentials");
                }
                var roles = await userManager.GetRolesAsync(user);
                var userInfo = new UserResponseDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Token = token
                };

                userInfo.Roles = roles.Select(r => new RoleResponseDto
                {
                    Id = r,
                    RoleName = r
                }).ToList();

                return Ok(userInfo);
            }

            return BadRequest("Invalid Credentials");
        }
    }
}
