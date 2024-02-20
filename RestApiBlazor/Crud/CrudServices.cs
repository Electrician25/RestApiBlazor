using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using RESTapi.Users;

namespace RESTapi.Crud
{
    public class CrudServices : ControllerBase
    {
        private readonly IMongoCollection<User> _booksCollection;

        public CrudServices(IMongoCollection<User> booksCollection)
        {
            _booksCollection = booksCollection;
        }

        public async Task CreateNewUserAsync(User user)
            => await _booksCollection.InsertOneAsync(user);

        public async Task<List<User>> GetAllUsersAsync()
            => await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<User> GetUserByIdAsync(int id)
            => await _booksCollection.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task UpdateUserAsync(int id, User updatedUser)
            => await _booksCollection.ReplaceOneAsync(userId => userId.Id == id, updatedUser);

        public async Task DeleteUserAsync(int id)
            => await _booksCollection.DeleteOneAsync(userId => userId.Id == id);
    }
}