using BlazorWA.ViewModels.Auth;
using BlazorWA.ViewModels.Models;

namespace BlazorWA.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse> Login(HttpContext context);
        Task<UserVM> GetUserByToken(string token);
        Task<bool> IsTokenExpired(string token);
    }
}
