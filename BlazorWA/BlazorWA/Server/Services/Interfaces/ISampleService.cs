using BlazorWA.Api.Auth;

namespace BlazorWA.Api.Services.Interfaces
{
    public interface ISampleService
    {
        Task<List<IdentityVM>> GetUsers();
    }
}
