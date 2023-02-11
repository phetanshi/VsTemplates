using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsTest.Api.Auth;
using PsTest.Api.Services.Interfaces;
using PsTest.Data.AppExceptions;
using PsTest.Data.Constants;

namespace PsTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AppBaseController
    {
        private readonly IAuthService _userService;

        public AuthController(IAuthService userService, IConfiguration config, ILogger<AuthController> logger) : base(config, logger)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [Authorize(AuthenticationSchemes = NegotiateDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Login()
        {
            await _userService.Login(HttpContext);
            return OkWrapper();
        }

        [HttpPost]
        [Route("istokenexpired")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> IsTokenExpired()
        {
            bool isTokenExpired = true;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                isTokenExpired = await _userService.IsTokenExpired(HttpContext);
                string msg = isTokenExpired ? AppConstants.TOKEN_EXPIRED : AppConstants.TOKEN_NOT_EXPIRED;
                return OkWrapper(true, msg, (object)isTokenExpired);
            }
            return OkWrapper(true, AppConstants.TOKEN_EXPIRED, (object)isTokenExpired);
        }

        [HttpPost]
        [Route("getuserbyjwt")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserByToken()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                IdentityVM data = await _userService.GetUserByToken(HttpContext);
                return OkWrapper(data);
            }
            else
                throw new UnauthorizedException(ErrorMessages.UNAUTHORIZED);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return OkWrapper();
        }
    }
}
