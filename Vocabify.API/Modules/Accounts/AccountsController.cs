using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vocabify.API.Models;
using Vocabify.API.Modules.Accounts.Models;
using Vocabify.API.Modules.Accounts.Services;
using Vocabify.API.Modules.Core.Exceptions;

namespace Vocabify.API.Modules.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            await _accountService.RegisterAsync(model);

            return Ok(new Message
            {
                Title = "User registered",
                Details = "Wait for administrator to give you an access"
            });
        }

        [HttpPost("confirm-email")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailModel model)
        {
            await _accountService.ConfirmEmailAsync(model);

            return Ok(new Message
            {
                Title = "Email confirmed",
                Details = "Your email address has been confirmed. You can sign in now"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            await _accountService.LoginAsync(model);

            return Ok(new Message
            {
                Title = "Signed in",
                Details = "You successfully signed in to your account"
            });
        }

        [HttpDelete("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();

            return NoContent();
        }

        [HttpGet("info")]
        [Authorize]
        public async Task<IActionResult> Info()
        {
            string? id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(id))
            {
                throw new UnauthorizedException("You are unauthorized to access data");
            }

            UserInfoModel userInfo = await _accountService.GetUserInfoAsync(id);

            return Ok(userInfo);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Users()
        {
            IEnumerable<UserInfoModel> users = await _accountService.GetUsersAsync();

            return Ok(users);
        }
    }
}
