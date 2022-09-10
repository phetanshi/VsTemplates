using BlazorWA.UI.Helpers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorWA.UI.Pages.ServiceHandlers.Definitions
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
        protected string GetServiceUri(string uriKey)
        {
            var uri = configuration[uriKey];
            return uri;
        }
        protected string GetServiceUri(string uriKey, Dictionary<string, string> queryStringsToBeApended)
        {
            var uri = configuration[uriKey];

            if (queryStringsToBeApended != null && queryStringsToBeApended.Count > 0)
            {
                uri = $"{uri}?";
                int i = 0;
                foreach (var queryString in queryStringsToBeApended)
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
        protected async Task<T> ReadApiResponseAsync<T>(HttpResponseMessage httpResponse)
        {
            T Obj = default;
            if (httpResponse.IsSuccessStatusCode && httpResponse.Content != null)
            {
                if (IsPrimitiveType(typeof(T)))
                {
                    var res = await httpResponse.Content.ReadAsStreamAsync();
                    Obj = (T)Convert.ChangeType(res, typeof(T));
                }
                else
                {
                    Obj = await httpResponse.Content.ReadFromJsonAsync<T>();
                }
            }
            return Obj;
        }

        protected async Task Get(string uriConfigKey)
        {
            var uri = GetServiceUri(uriConfigKey);
            await http.GetAsync(uri);
        }
        protected async Task<TResult> Get<TResult>(string uriConfigKey)
        {
            var uri = GetServiceUri(uriConfigKey);
            var response = await http.GetAsync(uri);
            TResult vm = await ReadApiResponseAsync<TResult>(response);
            return vm;
        }
        protected async Task<TResult> Post<TInput, TResult>(TInput vm, string uriConfigKey)
        {
            if (vm == null)
                throw new Exception(AppMessages.ViewModelNullErrorMessage);

            var uri = GetServiceUri(uriConfigKey);
            var response = await http.PostAsJsonAsync(uri, vm);
            TResult result = await ReadApiResponseAsync<TResult>(response);
            return result;
        }
        protected async Task<TResult> Post<TResult>(string uriConfigKey)
        {
            var uri = GetServiceUri(uriConfigKey);
            var response = await http.PostAsync(uri, null);
            TResult result = await ReadApiResponseAsync<TResult>(response);
            return result;
        }
        protected async Task<TResult> Post<TResult>(string stringContent, string uriConfigKey)
        {
            var uri = GetServiceUri(uriConfigKey);
            var requestMsg = new HttpRequestMessage(HttpMethod.Post, uri);
            var content = JsonSerializer.Serialize(stringContent);
            requestMsg.Content = new StringContent(content);
            requestMsg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await http.SendAsync(requestMsg);
            TResult result = await ReadApiResponseAsync<TResult>(response);
            return result;
        }
        private bool IsPrimitiveType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.String:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Boolean:
                case TypeCode.Double:
                    return true;
                default:
                    return false;
            }
        }
    }
}
