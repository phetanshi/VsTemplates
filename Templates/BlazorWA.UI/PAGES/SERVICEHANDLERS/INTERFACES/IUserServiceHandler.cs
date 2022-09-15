using $ext_projectname$.ViewModels.Auth;
using $ext_projectname$.ViewModels.Models;

namespace $safeprojectname$.Pages.ServiceHandlers.Interfaces
{
    public interface IUserServiceHandler
    {
        Task<AuthenticationResponse> LoginAsync();
        Task<bool> IsTokenExpiredAsync();
        Task<UserVM> GetLoginUserDetailsAsync();
    }
}
