using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsTest.UI.Components.Services
{
    public static class AppExtensions
    {
        public static IServiceCollection AddUILibraryServices(this IServiceCollection services)
        {
            return services.AddMudServices();
        }
    }
}
