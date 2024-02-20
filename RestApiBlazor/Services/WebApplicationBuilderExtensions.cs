using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using RESTapi.Data;

namespace RestApiBlazor.Services
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddApplicationContext(this WebApplicationBuilder builder)
        {
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<ApplicationContext>(options
            //        => options.UseMongoDB(connectionString, "users"));

            //return builder;
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseMongoDB(mongoClient, "users"));

            return builder;
        }
    }
}