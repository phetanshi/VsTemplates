

using BlazorWA.UI.Auth;

namespace BlazorWA.UI.Pages.ServiceHandlers.Interfaces
{
    public interface IUserServiceHandler
    {
        Task<AuthenticationResponse> LoginAsync();
        Task<bool> IsTokenExpiredAsync();
        Task<LoginUser> GetLoginUserDetailsAsync();
    }
}
