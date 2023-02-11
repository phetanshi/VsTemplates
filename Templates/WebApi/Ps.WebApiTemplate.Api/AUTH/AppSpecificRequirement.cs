using Microsoft.AspNetCore.Authorization;

namespace $safeprojectname$.Auth
{
    public class AppSpecificRequirement : IAuthorizationRequirement
    {
        //Fixed data that can come from policy registration. see example commented code below

        public AppSpecificRequirement()
        {
            
        }
        //public int MinimumAge { get; }
    }
}
