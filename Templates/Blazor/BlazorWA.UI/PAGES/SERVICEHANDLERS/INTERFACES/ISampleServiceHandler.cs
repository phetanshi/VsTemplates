using $safeprojectname$.Auth;

namespace $safeprojectname$.Pages.ServiceHandlers.Interfaces
{
    public interface ISampleServiceHandler
    {
        Task<List<Person>> GetUsersAsync();
    }
}
