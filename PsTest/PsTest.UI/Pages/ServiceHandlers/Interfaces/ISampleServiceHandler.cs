using PsTest.UI.Auth;

namespace PsTest.UI.Pages.ServiceHandlers.Interfaces
{
    public interface ISampleServiceHandler
    {
        Task<List<Person>> GetUsersAsync();
    }
}
