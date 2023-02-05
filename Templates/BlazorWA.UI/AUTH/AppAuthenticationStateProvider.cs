using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using $safeprojectname$.Pages.ServiceHandlers.Interfaces;
using System.Security.Claims;

namespace $safeprojectname$.Auth
{
    public class AppAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IUserServiceHandler userServiceHandler;

        public AppAuthenticationStateProvider(IUserServiceHandler userServiceHandler)
        {
            this.userServiceHandler = userServiceHandler;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var result = await userServiceHandler.LoginAsync();
            if (result.IsSuccess)
            {
                var loginUser = await userServiceHandler.GetLoginUserDetailsAsync();

                if (loginUser != null && !string.IsNullOrWhiteSpace(loginUser.UserId))
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, loginUser.UserId));
                    claims.Add(new Claim(ClaimTypes.Email, loginUser.Email ?? ""));
                    claims.Add(new Claim(AppClaimTypes.FirstName, loginUser.FirstName ?? ""));
                    claims.Add(new Claim(AppClaimTypes.LastName, loginUser.LastName ?? ""));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                    var authnticationState = new AuthenticationState(claimPrincipal);

                    return authnticationState;
                }
            }
            var claimsIdentityDefault = new ClaimsIdentity();
            var claimPrincipalDefault = new ClaimsPrincipal(claimsIdentityDefault);
            var authnticationStateDefault = new AuthenticationState(claimPrincipalDefault);
            return authnticationStateDefault;
        }
    }
}
