using BlazorWA.Api.AutoMapperProfiles;
using BlazorWA.Api.Services.Definitions;
using BlazorWA.Api.Services.Interfaces;
using BlazorWA.Data;
using BlazorWA.Data.Definitions;
using BlazorWA.Logging;

namespace BlazorWA.Api.AppStart
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
            services.AddScoped<IUserService, UserService>();
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
