using BlazorWA.UI.Auth;

namespace BlazorWA.UI.Pages.ServiceHandlers.Interfaces
{
    public interface ISampleServiceHandler
    {
        Task<List<LoginUser>> GetUsersAsync();
    }
}
