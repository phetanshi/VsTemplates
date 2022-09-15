using Helpers = $safeprojectname$.Helpers;
using $safeprojectname$.Pages.ServiceHandlers.Interfaces;
using $ext_projectname$.ViewModels.Models;

namespace $safeprojectname$.Pages.ServiceHandlers.Definitions
{
    public class SampleServiceHandler : ServiceHandlerBase, ISampleServiceHandler
    {
        public SampleServiceHandler(IConfiguration configuration, HttpClient http) : base(configuration, http)
        {
        }

        public async Task<List<UserVM>> GetUsersAsync()
        {
            return await Get<List<UserVM>>(Helpers.UriHelper.SampleUsers);
        }
    }
}
