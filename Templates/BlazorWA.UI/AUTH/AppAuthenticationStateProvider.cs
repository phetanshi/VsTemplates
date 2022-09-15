﻿using $safeprojectname$.Auth.Services;
using $safeprojectname$.Helpers;
using $safeprojectname$.Pages.ServiceHandlers.Interfaces;
using $ext_projectname$.ViewModels.Auth;
using $ext_projectname$.ViewModels.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

namespace $safeprojectname$.Auth
{
    public class AppAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IUserServiceHandler userServiceHandler;
        private readonly IAccessTokenService accessTokenService;

        public AppAuthenticationStateProvider(IUserServiceHandler userServiceHandler, IAccessTokenService accessTokenService)
        {
            this.userServiceHandler = userServiceHandler;
            this.accessTokenService = accessTokenService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationResponse authNResponse = await userServiceHandler.LoginAsync();
            
            if (authNResponse != null && !string.IsNullOrEmpty(authNResponse.Token))
            {
                await accessTokenService.SetAccessTokenAsync(AppMessages.TokenKey, authNResponse.Token);
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
