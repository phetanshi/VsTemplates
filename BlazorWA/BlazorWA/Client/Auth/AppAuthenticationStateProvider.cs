using BlazorWA.UI.Auth.Services;
using BlazorWA.UI.Helpers;
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
        private readonly HttpClient http;
        private readonly IAccessTokenService accessTokenService;
        private readonly IConfiguration config;

        public AppAuthenticationStateProvider(HttpClient http, IAccessTokenService accessTokenService, IConfiguration config)
        {
            this.http = http;
            this.accessTokenService = accessTokenService;
            this.config = config;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var loginUser = await GetLoginUserDetailsAsync();
            if(loginUser != null && !string.IsNullOrWhiteSpace(loginUser.UserId))
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

        private async Task<UserVM> GetLoginUserDetailsAsync()
        {
            var token = await accessTokenService.GetAccessTokenAsync("jwt_token");

            if (token == null) //Token not valid or might have expired
                return null;

            HttpResponseMessage tokenValidationResponse = await CallApiAsync(token, config[UriHelper.IsTokenExpired]);
            bool isTokenExpired = await ReadResponseAsync<bool>(tokenValidationResponse);

            if (isTokenExpired)
                return null;

            HttpResponseMessage response = await CallApiAsync(token, config[UriHelper.LoginUserDetails]);
            var user = await ReadResponseAsync<UserVM>(response);

            return user;
        }

        private async Task<T> ReadResponseAsync<T>(HttpResponseMessage response)
        {
            var responseStatusCode = response.StatusCode;
            T returnedValue = await response.Content.ReadFromJsonAsync<T>();

            if (returnedValue != null)
                return returnedValue;
            else
                return default(T);
        }

        private async Task<HttpResponseMessage> CallApiAsync(string token, string uri)
        {
            var requestMsg = new HttpRequestMessage(HttpMethod.Post, uri);
            var jwtToken = JsonSerializer.Serialize(token);
            requestMsg.Content = new StringContent(jwtToken);
            requestMsg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await http.SendAsync(requestMsg);
            return response;
        }
    }
}
