using BlazorWA.Data.Database;
using BlazorWA.Logging;
using Microsoft.EntityFrameworkCore;

namespace BlazorWA.Api.AppStart
{
    public static class DatabaseConfig
    {
        public static WebApplicationBuilder AddSqlServerDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddAppDatabase(builder.Configuration);
            builder.Logging.AddLoggingDatabase(builder.Configuration);
            return builder;
        }
        private static IServiceCollection AddAppDatabase(this IServiceCollection services, IConfiguration config)
        {
            string connStr = config.GetConnectionString("AppDbConnection");
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connStr));
            return services;
        }

        private static void AddLoggingDatabase(this ILoggingBuilder loggingBuilder, IConfiguration config)
        {
            string logConnStr = config.GetConnectionString("AppLogDbConnection");
            loggingBuilder.AddDbLogger(config =>
            {
                config.ConnectionString = logConnStr;
                config.LogLevel = new List<LogLevel>();
                config.LogLevel.Add(LogLevel.Warning);
                config.LogLevel.Add(LogLevel.Error);
                config.LogLevel.Add(LogLevel.Critical);
            });
        }
    }
}
