using Microsoft.AspNetCore.Authorization;
using Ps.WebApiTemplate.Api.Auth;
using Ps.WebApiTemplate.Api.AutoMapperProfiles;
using Ps.WebApiTemplate.Api.Services.Definitions;
using Ps.WebApiTemplate.Api.Services.Interfaces;
using Ps.WebApiTemplate.Data;
using Ps.WebApiTemplate.Data.Definitions;
using Ps.WebApiTemplate.Logging;

namespace Ps.WebApiTemplate.Api.AppStart
{
    public static class ObjectContainer
    {
        public static IServiceCollection AddApplicationObjects(this IServiceCollection services)
        {
            services.AddServiceDependencies();
            services.AddRepository();
            services.AddOthes();
            return services;
        }

        private static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthorizationHandler, AppSpecificHandler>();
            services.AddScoped<IAuthorizationHandler, WindowsAuthNHandler>();
        }
        private static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository, AppRepository>();
        }
        private static void AddOthes(this IServiceCollection services)
        {
            services.AddScoped<LogAttribute>();
            services.AddAutoMapper(typeof(EmployeeAutoMapperProfile));
        }
    }
}
