using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using $safeprojectname$.Application;

namespace $safeprojectname$
{
    internal class Program
    {
        public static IConfigurationRoot Configuration;
        static void Main(string[] args)
        {
            Console.WriteLine("App have been started..!");

            //1. Create Service Collection for DI
            //2. Build a Configuration 
            //3. Add configuration to the service collection
            //4. Run application


            //1. Create Service Collection for DI
            var services = new ServiceCollection();

            //2. Build a Configuration 
            var baseDir = Path.Combine(AppContext.BaseDirectory);
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(baseDir)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            //3. Add configuration to the service collection
            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<App>();
            //4. Run application
            var serviceProvider = services.BuildServiceProvider();
            var app = serviceProvider.GetService<App>();
            if (app != null)
                app.Run();

            Console.WriteLine("App have been ended..!");
        }
    }
}