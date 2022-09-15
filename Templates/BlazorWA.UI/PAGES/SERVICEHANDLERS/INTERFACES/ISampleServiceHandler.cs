using $ext_projectname$.ViewModels.Models;

namespace $safeprojectname$.Pages.ServiceHandlers.Interfaces
{
    public interface ISampleServiceHandler
    {
        Task<List<UserVM>> GetUsersAsync();
    }
}
