using Helpers = BlazorWA.UI.Helpers;
using BlazorWA.UI.Pages.ServiceHandlers.Interfaces;
using BlazorWA.ViewModels.Models;

namespace BlazorWA.UI.Pages.ServiceHandlers.Definitions
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
