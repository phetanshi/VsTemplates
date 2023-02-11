using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
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
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new AppSpecificRequirement());
                });

                options.AddPolicy("Windows", policy =>
                {
                    policy.AuthenticationSchemes.Add(NegotiateDefaults.AuthenticationScheme);
                    policy.Requirements.Add(new WindowsAuthNRequirement());
                });
            });
            return services;
        }
    }
}
