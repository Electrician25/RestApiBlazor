using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RESTapi.Users;
using RestApiBlazor.Entities;

namespace RESTapi.Data
{
    public class ApplicationContext
    {
        private readonly IMongoCollection<User> _booksCollection;

        public ApplicationContext(
            IOptions<UsersDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<User>(
                bookStoreDatabaseSettings.Value.UsersCollectionName);
        }
    }
}