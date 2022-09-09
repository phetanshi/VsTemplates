using BlazorWA.UI.Auth.Services;
using System.Net.Http.Headers;

namespace BlazorWA.UI.Auth
{
    public class AppAutherizationHandler : DelegatingHandler
    {
        private readonly IAccessTokenService accessTokenService;

        public AppAutherizationHandler(IAccessTokenService accessTokenService)
        {
            this.accessTokenService = accessTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await accessTokenService.GetAccessTokenAsync("jwt_token");

            if (token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
