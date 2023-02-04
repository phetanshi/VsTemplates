using BlazorWA.Api.Services.Interfaces;
using BlazorWA.Data;
using BlazorWA.Data.AppExceptions;
using BlazorWA.Data.Constants;
using BlazorWA.ViewModels.Auth;
using BlazorWA.ViewModels.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AppBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IConfiguration config, ILogger<UserController> logger) : base(config, logger)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [Authorize(AuthenticationSchemes = NegotiateDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Login()
        {
            AuthenticationResponse response = await _userService.Login(HttpContext);
            return OkWrapper(response);
        }

        [HttpPost]
        [Route("istokenexpired")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> IsTokenExpired()
        {
            bool isTokenExpired = true;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string token = HttpContext.Request.Headers["Authorization"].ToString().Split(' ')[1];
                isTokenExpired = await _userService.IsTokenExpired(token);
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
                string token = HttpContext.Request.Headers["Authorization"].ToString().Split(' ')[1];
                UserVM data = await _userService.GetUserByToken(token);
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
