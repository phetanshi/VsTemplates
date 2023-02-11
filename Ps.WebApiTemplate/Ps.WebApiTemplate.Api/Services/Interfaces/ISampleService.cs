using Ps.WebApiTemplate.Api.Auth;

namespace Ps.WebApiTemplate.Api.Services.Interfaces
{
    public interface ISampleService
    {
        Task<List<IdentityVM>> GetUsers();
    }
}
