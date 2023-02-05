using PsTest.UI.Auth;
using PsTest.UI.Helpers;

namespace PsTest.UI.Pages.ServiceHandlers.Interfaces
{
    public interface IUserServiceHandler
    {
        Task<ApiResponse> LoginAsync();
        Task<bool> IsTokenExpiredAsync();
        Task<Person> GetLoginUserDetailsAsync();
    }
}
