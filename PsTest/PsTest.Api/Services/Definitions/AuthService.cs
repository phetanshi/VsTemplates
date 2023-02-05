using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PsTest.Api.Auth;
using PsTest.Api.Services.Interfaces;
using PsTest.Data;
using PsTest.Data.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace PsTest.Api.Services.Definitions
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AuthService> _logger;
        private readonly byte[]? _secureKeyBytes;
        public AuthService(IConfiguration config, ILogger<AuthService> logger)
        {
            this._config = config;
            this._logger = logger;
            string secureKey = config[ConfigConstants.JwtSecurityKey];
            _secureKeyBytes = Encoding.ASCII.GetBytes(secureKey);
        }

        public async Task<IdentityVM> GetUserByToken(HttpContext context)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_secureKeyBytes),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };

            if (context != null && context.Request != null && context.Request.Cookies != null)
            {
                string token = context.Request.Cookies["access_token"];
                var tokenHandler = new JwtSecurityTokenHandler();
                var principle = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                var jwtSecurityToken = (JwtSecurityToken)securityToken;
                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (userId != null)
                    {
                        IdentityVM user = new IdentityVM();
                        user.UserId = userId;

                        //Uncomment below to add few more claims
                        //user.FirstName = "<first name>";
                        //user.LastName = "<last name>";

                        return await Task.FromResult(user);
                    }
                }
            }
            
            return null;
        }

        public async Task<bool> IsTokenExpired(HttpContext context)
        {
            bool hasExpired = true;

            if(context != null && context.Request != null && context.Request.Cookies != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                string jwtToken = context.Request.Cookies["access_token"];
                var token = tokenHandler.ReadJwtToken(jwtToken);
                hasExpired = token.ValidTo < DateTime.UtcNow;
            }
            
            return await Task.FromResult(hasExpired);
        }

        public async Task<AuthenticationResponse> Login(HttpContext context)
        {
            if (context == null)
                throw new Exception(ErrorMessages.HTTP_CONTEXT_NOT_FOUND);

            IdentityVM userVm = new IdentityVM();
            userVm.UserId = GetLoginUserId(context);

            AuthenticationResponse authenticationResponse = new AuthenticationResponse();
            if (!string.IsNullOrWhiteSpace(userVm.UserId))
            {
                authenticationResponse.Token = GenerateJwtToken(userVm);
            }
            context.Response.Cookies.Append("access_token", authenticationResponse.Token, new CookieOptions { HttpOnly = true });
            return await Task.FromResult(authenticationResponse);
        }

        private string GetLoginUserId(HttpContext httpContext)
        {
            string userId = "";

            if (httpContext.User.Identity.IsAuthenticated)
                userId = httpContext.User.Identity.Name;
            else
                userId = WindowsIdentity.GetCurrent().Name;

            return userId;
        }

        private string GenerateJwtToken(IdentityVM userVm)
        {
            var claimUserId = new Claim(ClaimTypes.NameIdentifier, userVm.UserId);
            var claimEmail = new Claim(ClaimTypes.Email, userVm.Email ?? "");
            var claimFirstName = new Claim(AppClaimTypes.FirstName, userVm.FirstName ?? "");
            var claimLastName = new Claim(AppClaimTypes.LastName, userVm.LastName ?? "");

            var claimsIdentity = new ClaimsIdentity(new[] { claimUserId, claimEmail, claimFirstName, claimLastName }, AppConstants.AuthenticationType);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(AppConstants.ExpiryTimeInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secureKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);
            return tokenStr;
        }
    }
}
