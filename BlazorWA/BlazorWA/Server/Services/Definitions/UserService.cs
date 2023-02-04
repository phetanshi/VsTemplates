using BlazorWA.Api.Services.Interfaces;
using BlazorWA.Data;
using BlazorWA.Data.Constants;
using BlazorWA.ViewModels.Auth;
using BlazorWA.ViewModels.Models;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace BlazorWA.Api.Services.Definitions
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<UserService> _logger;
        private readonly byte[]? _secureKeyBytes;
        public UserService(IConfiguration config, ILogger<UserService> logger)
        {
            this._config = config;
            this._logger = logger;
            string secureKey = config[ConfigConstants.JwtSecurityKey];
            _secureKeyBytes = Encoding.ASCII.GetBytes(secureKey);
        }

        public async Task<UserVM> GetUserByToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_secureKeyBytes),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principle = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = (JwtSecurityToken)securityToken;

            if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId != null)
                {
                    UserVM user = new UserVM();
                    user.UserId = userId;

                    //Uncomment below to add few more claims
                    //user.FirstName = "<first name>";
                    //user.LastName = "<last name>";

                    return await Task.FromResult(user);
                }
            }
            return null;
        }

        public async Task<bool> IsTokenExpired(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var hasExpired = token.ValidTo < DateTime.UtcNow;
            return await Task.FromResult(hasExpired);
        }

        public async Task<AuthenticationResponse> Login(HttpContext context)
        {
            if (context == null)
                throw new Exception(ErrorMessages.HTTP_CONTEXT_NOT_FOUND);

            UserVM userVm = new UserVM();
            userVm.UserId = GetLoginUserId(context);

            AuthenticationResponse authenticationResponse = new AuthenticationResponse();
            if (!string.IsNullOrWhiteSpace(userVm.UserId))
            {
                authenticationResponse.Token = GenerateJwtToken(userVm);
            }

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

        private string GenerateJwtToken(UserVM userVm)
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
