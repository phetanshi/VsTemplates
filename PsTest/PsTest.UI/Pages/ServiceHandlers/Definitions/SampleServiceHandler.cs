using PsTest.UI.Auth;
using PsTest.UI.Helpers;
using PsTest.UI.Pages.ServiceHandlers.Interfaces;
using System.Text.Json;

namespace PsTest.UI.Pages.ServiceHandlers.Definitions
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
