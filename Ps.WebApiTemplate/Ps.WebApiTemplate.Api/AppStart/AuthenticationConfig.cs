using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ps.WebApiTemplate.Api.AppStart
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection AddAuthenticationSchemes(this IServiceCollection services, IConfiguration config)
        {
            services.AddNegotiateAuthentication(); //For Windows Authentication
            services.AddAppSpecificJwtTokenAuthentication(config);
            return services;
        }
        private static void AddNegotiateAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
        }
        private static void AddAppSpecificJwtTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddAppSpecificJwtBearer(config["Authentication:JWTSettings:SecretKey"]);

        }
        private static AuthenticationBuilder AddAppSpecificJwtBearer(this AuthenticationBuilder builder, string securityKey)
        {
            builder.AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.RequireHttpsMetadata = true;
                jwtBearerOptions.SaveToken = true;
                jwtBearerOptions.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["access_token"];
                        return Task.CompletedTask;
                    }
                };
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            return builder;
        }
    }
}
