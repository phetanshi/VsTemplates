using $ext_projectname$.Domain;
using $ext_projectname$.ViewModels.Models;

namespace $safeprojectname$.Services.Interfaces
{
    public interface ISampleService
    {
        Task<List<UserVM>> GetUsers();
    }
}
