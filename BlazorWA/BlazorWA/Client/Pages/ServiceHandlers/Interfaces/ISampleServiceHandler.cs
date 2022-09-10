using BlazorWA.ViewModels.Models;

namespace BlazorWA.UI.Pages.ServiceHandlers.Interfaces
{
    public interface ISampleServiceHandler
    {
        Task<List<UserVM>> GetUsersAsync();
    }
}
