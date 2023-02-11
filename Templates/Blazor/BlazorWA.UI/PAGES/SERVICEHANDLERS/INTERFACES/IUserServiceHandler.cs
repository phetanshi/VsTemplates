using $safeprojectname$.Auth;
using $safeprojectname$.Helpers;

namespace $safeprojectname$.Pages.ServiceHandlers.Interfaces
{
    public interface IUserServiceHandler
    {
        Task<ApiResponse> LoginAsync();
        Task<bool> IsTokenExpiredAsync();
        Task<Person> GetLoginUserDetailsAsync();
    }
}
