using $ext_projectname$.ViewModels.Auth;
using $ext_projectname$.ViewModels.Models;

namespace $safeprojectname$.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse> Login(HttpContext context);
        Task<UserVM> GetUserByToken(string token);
        Task<bool> IsTokenExpired(string token);
    }
}
