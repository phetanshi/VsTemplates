using Microsoft.Extensions.Options;
using Ps.WebApiTemplate.Api.Auth;

namespace Ps.WebApiTemplate.Api.AppStart
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
