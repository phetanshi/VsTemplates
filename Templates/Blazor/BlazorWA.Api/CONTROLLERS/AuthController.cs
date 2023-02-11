using $safeprojectname$.Auth;
using $safeprojectname$.Services.Interfaces;
using $ext_projectname$.Data.AppExceptions;
using $ext_projectname$.Data.Constants;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
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
                return OkWrapper(isTokenExpired, msg);
            }
            return OkWrapper(isTokenExpired, AppConstants.TOKEN_EXPIRED);
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
