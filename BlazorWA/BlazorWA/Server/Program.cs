using BlazorWA.Api.AppStart;
using BlazorWA.Api.Auth;
using BlazorWA.Api.AutoMapperProfiles;
using BlazorWA.Api.Services.Definitions;
using BlazorWA.Api.Services.Interfaces;
using BlazorWA.Data;
using BlazorWA.Data.Database;
using BlazorWA.Data.Definitions;
using BlazorWA.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BlazorWA.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddSqlServerDatabase();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddDependencies();
            builder.Services.AddAuthenticationSchemes(builder.Configuration);
            builder.Services.AddSwaggerWithAutherization();

            builder.Build().AddMiddlewares();

        }
    }
}