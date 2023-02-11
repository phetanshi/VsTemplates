using $safeprojectname$.Auth;

namespace $safeprojectname$.Services.Interfaces
{
    public interface ISampleService
    {
        Task<List<IdentityVM>> GetUsers();
    }
}
