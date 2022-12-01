using $safeprojectname$.Services.Interfaces;
using $ext_projectname$.Domain.AppExceptions;
using $ext_projectname$.Domain.Models;
using $ext_projectname$.ViewModels.Auth;
using $ext_projectname$.ViewModels.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IUserService userService;
        private readonly ILogger<UserController> _logger;
        

        public UserController(IConfiguration config, IUserService userService, ILogger<UserController> logger)
        {
            this.config = config;
            this.userService = userService;
            this._logger = logger;
        }

        [HttpPost]
        [Route("login")]
        [Authorize(AuthenticationSchemes = NegotiateDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AuthenticationResponse>> Login()
        {
            try
            {
                return await userService.Login(HttpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, AppConstants.ErrorMessages.UNHANDLED_EXCEPTION);
            }
        }

        [HttpPost]
        [Route("istokenexpired")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> IsTokenExpired()
        {
            try
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    string token = HttpContext.Request.Headers["Authorization"].ToString().Split(' ')[1];
                    return await userService.IsTokenExpired(token);
                }
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, AppConstants.ErrorMessages.UNHANDLED_EXCEPTION);
            }
        }

        [HttpPost]
        [Route("getuserbyjwt")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserVM>> GetUserByToken()
        {
            try
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    string token = HttpContext.Request.Headers["Authorization"].ToString().Split(' ')[1];
                    return await userService.GetUserByToken(token);
                }
                else
                    throw new UnauthorizedException(AppConstants.ErrorMessages.UNAUTHORIZED);
            }
            catch(UnauthorizedException ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, AppConstants.ErrorMessages.UNHANDLED_EXCEPTION);
            }
        }

        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, AppConstants.ErrorMessages.UNHANDLED_EXCEPTION);
            }
        }
    }
}
