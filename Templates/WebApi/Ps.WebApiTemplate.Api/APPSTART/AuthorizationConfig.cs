using Microsoft.Extensions.Options;
using $safeprojectname$.Auth;

namespace $safeprojectname$.AppStart
{
    public static class AuthorizationConfig
    {
        public static IServiceCollection AddAppAuthorization(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AppPolicyName", policy =>
                {
                    policy.Requirements.Add(new AppSpecificRequirement());
                });
            });
            return services;
        }
    }
}
