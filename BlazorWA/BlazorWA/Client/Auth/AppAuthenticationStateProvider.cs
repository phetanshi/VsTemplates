using BlazorWA.UI.Auth.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWA.UI.Auth
{
    public class AppAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient http;
        private readonly IAccessTokenService accessTokenService;

        public AppAuthenticationStateProvider(HttpClient http, IAccessTokenService accessTokenService)
        {
            this.http = http;
            this.accessTokenService = accessTokenService;
        }
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
