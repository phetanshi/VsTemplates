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
            string token = await accessTokenService.GetAccessTokenAsync(AppMessages.TokenKey);
            return await GetLoginUserDetailsAsync(token);
        }

        public async Task<UserVM> GetLoginUserDetailsAsync(string token)
        {
            UserVM user = null;
            if (token != null)
            {
                if (await IsTokenExpiredAsync(token))
                    return null;
                user = await Post<UserVM>(token, UriHelper.LoginUserDetails);
            }
            return user;
        }

        public async Task<bool> IsTokenExpiredAsync()
        {
            string token = await accessTokenService.GetAccessTokenAsync(AppMessages.TokenKey);
            return await IsTokenExpiredAsync(token);
        }

        public async Task<bool> IsTokenExpiredAsync(string token)
        {
            if (token != null)
                return await Post<bool>(token, UriHelper.IsTokenExpired);
            return true;
        }

        public async Task<AuthenticationResponse> LoginAsync()
        {
            var authNResponse = await Post<AuthenticationResponse>(UriHelper.Login);
            return authNResponse;
        }
    }
}
