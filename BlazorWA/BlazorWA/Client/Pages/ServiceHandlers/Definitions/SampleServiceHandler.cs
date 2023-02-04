using Helpers = BlazorWA.UI.Helpers;
using BlazorWA.UI.Pages.ServiceHandlers.Interfaces;
using BlazorWA.UI.Auth;

namespace BlazorWA.UI.Pages.ServiceHandlers.Definitions
{
    public class SampleServiceHandler : ServiceHandlerBase, ISampleServiceHandler
    {
        public SampleServiceHandler(IConfiguration configuration, HttpClient http) : base(configuration, http)
        {
        }

        public async Task<List<LoginUser>> GetUsersAsync()
        {
            return await Get<List<LoginUser>>(Helpers.UriHelper.SampleUsers);
        }
    }
}
