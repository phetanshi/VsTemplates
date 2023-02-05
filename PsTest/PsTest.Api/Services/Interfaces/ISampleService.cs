using PsTest.Api.Auth;

namespace PsTest.Api.Services.Interfaces
{
    public interface ISampleService
    {
        Task<List<IdentityVM>> GetUsers();
    }
}
