using BlazorWA.ViewModels.Auth;
using BlazorWA.ViewModels.Models;

namespace BlazorWA.UI.Pages.ServiceHandlers.Interfaces
{
    public interface IUserServiceHandler
    {
        Task<AuthenticationResponse> LoginAsync();
        Task<bool> IsTokenExpiredAsync();
        Task<bool> IsTokenExpiredAsync(string token);
        Task<UserVM> GetLoginUserDetailsAsync();
        Task<UserVM> GetLoginUserDetailsAsync(string token);
    }
}
