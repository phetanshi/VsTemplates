using BlazorWA.UI.Auth.Services;
using Helpers = BlazorWA.UI.Helpers;
using BlazorWA.UI.Pages.ServiceHandlers.Interfaces;
using BlazorWA.UI.Auth;

namespace BlazorWA.UI.Pages.ServiceHandlers.Definitions
{
    public class UserServiceHandler : ServiceHandlerBase, IUserServiceHandler
    {
        private readonly IAccessTokenService accessTokenService;

        public UserServiceHandler(IAccessTokenService accessTokenService, IConfiguration configuration, HttpClient http) : base(configuration, http)
        {
            this.accessTokenService = accessTokenService;
        }

        public async Task<LoginUser> GetLoginUserDetailsAsync()
        {
            bool isExpired = await IsTokenExpiredAsync();

            if (isExpired)
                return null;

            return await Post<LoginUser>(Helpers.UriHelper.LoginUserDetails);
        }

        public async Task<bool> IsTokenExpiredAsync()
        {
            return await Post<bool>(Helpers.UriHelper.IsTokenExpired);
        }

        public async Task<AuthenticationResponse> LoginAsync()
        {
            return await Post<AuthenticationResponse>(Helpers.UriHelper.Login);
        }
    }
}
