using BlazorWA.UI.Helpers;

using System.Net;
using System.Net.Http.Json;

namespace BlazorWA.UI.ServiceHandlers.Definitions
{
    public abstract class ServiceHandlerBase
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient http;

        public ServiceHandlerBase(IConfiguration configuration, HttpClient http)
        {
            this.configuration = configuration;
            this.http = http;
        }

        public string GetServiceUri(string uriKey )
        {
            var uri = configuration[uriKey];
            return uri;
        }
        public string GetServiceUri(string uriKey, Dictionary<string, string> queryStringsToBeApended)
        {
            var uri = configuration[uriKey];

            if(queryStringsToBeApended != null && queryStringsToBeApended.Count > 0)
            {
                uri = $"{uri}?";
                int i = 0;
                foreach(var queryString in queryStringsToBeApended)
                {
                    i++;
                    var encodedVal = WebUtility.UrlEncode(queryString.Value);
                    if (i <= 1)
                        uri = $"{uri}{queryString.Key}={queryString.Value}";
                    else
                        uri = $"{uri}&{queryString.Key}={queryString.Value}";
                }
            }
            return uri;
        }


    }
}
