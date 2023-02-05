using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PsTest.Api.AppStart;
using PsTest.Api.AutoMapperProfiles;
using PsTest.Api.Services.Definitions;
using PsTest.Api.Services.Interfaces;
using PsTest.Data;
using PsTest.Data.Database;
using PsTest.Data.Definitions;
using PsTest.Logging;

namespace PsTest.Api
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