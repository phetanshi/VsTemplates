using $safeprojectname$.Auth;
using $safeprojectname$.Helpers;
using $safeprojectname$.Pages.ServiceHandlers.Interfaces;
using System.Text.Json;

namespace $safeprojectname$.Pages.ServiceHandlers.Definitions
{
    public class SampleServiceHandler : ServiceHandlerBase, ISampleServiceHandler
    {
        public SampleServiceHandler(IConfiguration configuration, HttpClient http) : base(configuration, http)
        {
        }

        public async Task<List<Person>> GetUsersAsync()
        {
            List<Person> persons = new List<Person>();
            var apiResponse = await Get<ApiResponse>(Helpers.UriHelper.SampleUsers);
            if(apiResponse.IsSuccess)
            {
                persons = ((JsonElement)(apiResponse.Payload)).ToObject<List<Person>>();
            }
            return persons;
        }
    }
}
