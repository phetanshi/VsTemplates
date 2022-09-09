using BlazorWA.UI;
using BlazorWA.UI.Auth;
using BlazorWA.UI.Auth.Services;
using BlazorWA.UI.Auth.Services.Definitions;
using BlazorWA.UI.ServiceHandlers.Definitions;
using BlazorWA.UI.ServiceHandlers.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorWA.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var baseAddress = new Uri(builder.HostEnvironment.BaseAddress);

            builder.Services.AddHttpClient<ISampleServiceHandler, SampleServiceHandler>("SampleServiceClient", client =>
            {
                client.BaseAddress = baseAddress;
            });
            builder.Services.AddHttpClient<AuthenticationStateProvider, AppAuthenticationStateProvider>("AuthenticationStateProviderClient", client =>
            {
                client.BaseAddress = baseAddress;
            });

            builder.Services.AddScoped<IAccessTokenService, AppAccessTokenService>();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            //builder.Services.AddMsalAuthentication(options =>
            //{
            //    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
            //    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://api.id.uri/access_as_user");
            //});

            await builder.Build().RunAsync();
        }
    }
}