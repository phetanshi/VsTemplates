using BlazorWA.UI.Auth.Services;
using BlazorWA.UI.Helpers;
using BlazorWA.UI.Pages.ServiceHandlers.Interfaces;
using BlazorWA.ViewModels.Auth;
using BlazorWA.ViewModels.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

namespace BlazorWA.UI.Auth
{
    public class AppAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IUserServiceHandler userServiceHandler;
        private readonly HttpClient http;
        private readonly IAccessTokenService accessTokenService;
        private readonly IConfiguration config;

        public AppAuthenticationStateProvider(IUserServiceHandler userServiceHandler, HttpClient http, IAccessTokenService accessTokenService, IConfiguration config)
        {
            this.userServiceHandler = userServiceHandler;
            this.http = http;
            this.accessTokenService = accessTokenService;
            this.config = config;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationResponse authNResponse = await userServiceHandler.LoginAsync();
            var loginUser = await userServiceHandler.GetLoginUserDetailsAsync(authNResponse.Token);
            if (loginUser != null && !string.IsNullOrWhiteSpace(loginUser.UserId))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loginUser.UserId),
                    new Claim(ClaimTypes.Email, loginUser.Email ?? ""),
                    new Claim(AppClaimTypes.FirstName, loginUser.FirstName ?? ""),
                    new Claim(AppClaimTypes.LastName, loginUser.LastName ?? "")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authnticationState = new AuthenticationState(claimPrincipal);

                return authnticationState;
            }
            else
            {
                var claimsIdentity = new ClaimsIdentity();
                var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authnticationState = new AuthenticationState(claimPrincipal);
                return authnticationState;
            }
        }
    }
}
