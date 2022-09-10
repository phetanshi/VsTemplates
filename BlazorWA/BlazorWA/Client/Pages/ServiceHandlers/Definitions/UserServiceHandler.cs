using BlazorWA.UI.Auth.Services;
using BlazorWA.UI.Helpers;
using BlazorWA.UI.Pages.ServiceHandlers.Interfaces;
using BlazorWA.ViewModels.Auth;
using BlazorWA.ViewModels.Models;

namespace BlazorWA.UI.Pages.ServiceHandlers.Definitions
{
    public class UserServiceHandler : ServiceHandlerBase, IUserServiceHandler
    {
        private readonly IAccessTokenService accessTokenService;

        public UserServiceHandler(IAccessTokenService accessTokenService, IConfiguration configuration, HttpClient http) : base(configuration, http)
        {
            this.accessTokenService = accessTokenService;
        }

        public async Task<UserVM> GetLoginUserDetailsAsync()
        {
            bool isExpired = await IsTokenExpiredAsync();

            if (isExpired)
                return null;

            return await Post<UserVM>(UriHelper.LoginUserDetails);
        }

        public async Task<bool> IsTokenExpiredAsync()
        {
            return await Post<bool>(UriHelper.IsTokenExpired);
        }

        public async Task<AuthenticationResponse> LoginAsync()
        {
            return await Post<AuthenticationResponse>(UriHelper.Login);
        }
    }
}
