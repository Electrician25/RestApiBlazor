using Microsoft.EntityFrameworkCore;
using RESTapi.Data;

namespace RestApiBlazor.Services
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddApplicationContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options
                    => options.UseMongoDB(connectionString, "users"));

            return builder;
        }
    }
}