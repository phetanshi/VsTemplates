namespace BlazorWA.Api.AppStart
{
    public static class AppServices
    {
        public static WebApplicationBuilder AddAppServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddApplicationObjects();
            builder.Services.AddAuthenticationSchemes(builder.Configuration);
            builder.Services.AddSwaggerWithAutherization();
            return builder;
        }
    }
}
