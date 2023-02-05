using $safeprojectname$.Auth;

namespace $safeprojectname$.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticationResponse> Login(HttpContext context);
        Task<IdentityVM> GetUserByToken(HttpContext context);
        Task<bool> IsTokenExpired(HttpContext context);
    }
}
