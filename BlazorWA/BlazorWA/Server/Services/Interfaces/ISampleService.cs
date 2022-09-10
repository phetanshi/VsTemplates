using BlazorWA.Domain;
using BlazorWA.ViewModels.Models;

namespace BlazorWA.Api.Services.Interfaces
{
    public interface ISampleService
    {
        Task<string> Greet();
        Task<List<UserVM>> GetUsers();
    }
}
