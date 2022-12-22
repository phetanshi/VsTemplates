using BlazorWA.ViewModels.Models;

namespace BlazorWA.Api.Services.Interfaces
{
    public interface ISampleService
    {
        Task<List<UserVM>> GetUsers();
    }
}
