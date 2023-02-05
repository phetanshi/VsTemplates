using PsTest.UI.Auth;
using PsTest.UI.Helpers;
using PsTest.UI.Pages.ServiceHandlers.Interfaces;
using System.Text.Json;

namespace PsTest.UI.Pages.ServiceHandlers.Definitions
{
    public class UserServiceHandler : ServiceHandlerBase, IUserServiceHandler
    {
        public UserServiceHandler(IConfiguration configuration, HttpClient http) : base(configuration, http)
        {
        }

        public async Task<Person> GetLoginUserDetailsAsync()
        {
            bool isTokenExpired = await IsTokenExpiredAsync();

            if(!isTokenExpired)
            {
                var apiResponse = await Post<ApiResponse>(UriHelper.LoginUserDetails);

                if (!apiResponse.IsSuccess)
                    return null;

                Person loginUser = ((JsonElement)(apiResponse.Payload)).ToObject<Person>();
                return loginUser;
            }
            return null;
        }

        public async Task<bool> IsTokenExpiredAsync()
        {
            var apiResponse = await Post<ApiResponse>(UriHelper.IsTokenExpired);

            if (!apiResponse.IsSuccess)
                return false;

            bool isTokenExpired = ((JsonElement)(apiResponse.Payload)).GetBoolean();
            return isTokenExpired;
        }

        public async Task<ApiResponse> LoginAsync()
        {
            return await Post<ApiResponse>(UriHelper.Login);
        }
    }
}
