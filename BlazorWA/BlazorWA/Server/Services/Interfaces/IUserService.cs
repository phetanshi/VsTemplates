using BlazorWA.Api.Auth;

namespace BlazorWA.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse> Login(HttpContext context);
        Task<IdentityVM> GetUserByToken(string token);
        Task<bool> IsTokenExpired(string token);
    }
}
