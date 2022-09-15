﻿using $safeprojectname$.Auth.Services;
using Helper = $safeprojectname$.Helpers;
using System.Net.Http.Headers;

namespace $safeprojectname$.Auth
{
    public class AppAutherizationHandler : DelegatingHandler
    {
        private readonly IConfiguration configuration;
        private readonly IAccessTokenService accessTokenService;

        public AppAutherizationHandler(IConfiguration configuration, IAccessTokenService accessTokenService)
        {
            this.configuration = configuration;
            this.accessTokenService = accessTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await accessTokenService.GetAccessTokenAsync(Helper.AppMessages.TokenKey);

            var uri = request.RequestUri?.AbsoluteUri;

            if (token != null && !uri.Contains(configuration[Helper.UriHelper.Login]))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
