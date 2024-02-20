using RestApiBlazor.Entities;

namespace RestApiBlazor.Services
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddApplicationContext(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<UsersDatabaseSettings>(
                 builder.Configuration.GetSection("UsersDatabase"));

            return builder;
        }
    }
}