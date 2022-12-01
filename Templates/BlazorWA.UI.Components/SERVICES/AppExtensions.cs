using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;

namespace $safeprojectname$.Services
{
    public static class AppExtensions
    {
        public static IServiceCollection AddUILibraryServices(this IServiceCollection services)
        {
            return services.AddMudServices();
        }
    }
}
