using PsTest.Api.AutoMapperProfiles;
using PsTest.Api.Services.Definitions;
using PsTest.Api.Services.Interfaces;
using PsTest.Data;
using PsTest.Data.Definitions;
using PsTest.Logging;

namespace PsTest.Api.AppStart
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
