using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Identity.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Negotiate;
using System.Text;
using BlazorWA.Api.Auth;


using BlazorWA.Logging;
using BlazorWA.Data;
using BlazorWA.Data.Definitions;
using BlazorWA.Data.Database;
using BlazorWA.Api.AutoMapperProfiles;
using BlazorWA.Api.Services.Definitions;
using Microsoft.OpenApi.Models;
using BlazorWA.Api.Services.Interfaces;

namespace BlazorWA.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connStr = builder.Configuration.GetConnectionString("AppDbConnection");
            string LogConnStr = builder.Configuration.GetConnectionString("AppLogDbConnection");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connStr));
            builder.Logging.AddDbLogger(config =>
            {
                config.ConnectionString = LogConnStr;
                config.LogLevel = new List<LogLevel>();
                config.LogLevel.Add(LogLevel.Warning);
                config.LogLevel.Add(LogLevel.Error);
                config.LogLevel.Add(LogLevel.Critical);
            });

            builder.Services.AddScoped<LogAttribute>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ISampleService, SampleService>();
            builder.Services.AddScoped<ISampleRepository, SampleRepository>();

            builder.Services.AddAutoMapper(typeof(EmployeeAutoMapperProfile));


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddCustomJwtBearer(builder.Configuration["Authentication:JWTSettings:SecretKey"]);

            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });

            });
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapRazorPages();
            app.MapControllers();

            app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}