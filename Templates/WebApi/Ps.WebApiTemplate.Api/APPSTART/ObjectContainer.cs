using Microsoft.AspNetCore.Authorization;
using $safeprojectname$.Auth;
using $safeprojectname$.AutoMapperProfiles;
using $safeprojectname$.Services.Definitions;
using $safeprojectname$.Services.Interfaces;
using $ext_projectname$.Data;
using $ext_projectname$.Data.Definitions;
using $ext_projectname$.Logging;

namespace $safeprojectname$.AppStart
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
