using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

using BlazorWA.ViewModels.Auth;
using BlazorWA.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Negotiate;

namespace BlazorWA.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly ILogger<UserController> logger;
        private readonly byte[]? secureKeyBytes;

        public UserController(IConfiguration config, ILogger<UserController> logger)
        {
            this.config = config;
            this.logger = logger;

            string secureKey = config["Authentication:JWTSettings:SecretKey"];
            secureKeyBytes = Encoding.ASCII.GetBytes(secureKey);
        }

        [HttpPost]
        [Route("login")]
        [Authorize(AuthenticationSchemes = NegotiateDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AuthenticationResponse>> Login()
        {
            string token = string.Empty;
            UserVM userVm = new UserVM();

            if (HttpContext.User.Identity.IsAuthenticated)
                userVm.UserId = HttpContext.User.Identity.Name;

            if (!string.IsNullOrWhiteSpace(userVm.UserId))
            {
                token = GenerateJwtToken(userVm);
            }
            return await Task.FromResult(new AuthenticationResponse() { Token = token });
        }

        [HttpPost]
        [Route("istokenexpired")]
        public async Task<ActionResult<bool>> IsTokenExpired([FromBody] string jwtToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(jwtToken);
                var hasExpired = token.ValidTo < DateTime.UtcNow;
                return hasExpired;
            }
            catch (SecurityTokenException ex)
            {
                logger.LogError(ex.Message, ex);
                return false;
            }

            return false;
        }

        [HttpPost]
        [Route("getuserbyjwt")]
        public async Task<ActionResult<UserVM>> GetUserByJwt([FromBody] string jwtToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secureKeyBytes),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principle = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = (JwtSecurityToken)securityToken;

            if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId != null)
                {
                    UserVM user = new UserVM();
                    user.UserId = userId;
                    user.FirstName = "Hetanshi";
                    user.LastName = "Pottepalem";
                    return user;
                }
            }

            return null;
        }

        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        private string GenerateJwtToken(UserVM userVm)
        {
            var claimUserId = new Claim(ClaimTypes.NameIdentifier, userVm.UserId);
            var claimEmail = new Claim(ClaimTypes.Email, userVm.Email ?? "");
            var claimFirstName = new Claim(AppClaimTypes.FirstName, userVm.FirstName ?? "");
            var claimLastName = new Claim(AppClaimTypes.LastName, userVm.LastName ?? "");

            var claimsIdentity = new ClaimsIdentity(new[] { claimUserId, claimEmail, claimFirstName, claimLastName }, "JwtServerAuth");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secureKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);
            return tokenStr;
        }
    }
}
