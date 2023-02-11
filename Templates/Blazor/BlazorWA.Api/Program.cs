using $safeprojectname$.AppStart;
using $safeprojectname$.AutoMapperProfiles;
using $safeprojectname$.Services.Definitions;
using $safeprojectname$.Services.Interfaces;
using $ext_projectname$.Data;
using $ext_projectname$.Data.Database;
using $ext_projectname$.Data.Definitions;
using $ext_projectname$.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace $safeprojectname$
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddSqlServerDatabase()
                    .AddAppServices()
                    .Build()
                    .AddMiddlewares();
        }
    }
}