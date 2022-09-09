using Microsoft.JSInterop;

namespace BlazorWA.UI.Auth.Services.Definitions
{
    public class AppAccessTokenService : IAccessTokenService
    {
        private readonly IJSRuntime jSRuntime;

        public AppAccessTokenService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }
        public async Task<string> GetAccessTokenAsync(string tokenName)
        {
            return await jSRuntime.InvokeAsync<string>("localStorage.getItem", tokenName);
        }

        public async Task RemoveAccessTokenAsync(string tokenName)
        {
            await jSRuntime.InvokeAsync<string>("localStorage.removeItem", tokenName);
        }

        public async Task SetAccessTokenAsync(string tokenName, string tokenValue)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", tokenName, tokenValue);
        }
    }
}
