using AmdarisProject.Api.Infrastructure.Configurations;
using AmdarisProject.Common.Dtos.User;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AmdarisProject.Api.Controllers
{
    [Route("api/account")]
    public class AccountController : AppControllerBase
    {
        private readonly JwtAuthOptions _jwtAuthOptions;
        private readonly IAccountService _accountService;

        public AccountController(IOptions<JwtAuthOptions> jwtAuthOptions, AccountService accountService)
        {
            _accountService = accountService;
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            return Ok();
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _accountService.RegisterUserAsync(userRegisterDto);

            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}
