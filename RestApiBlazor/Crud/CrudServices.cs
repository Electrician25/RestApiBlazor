using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTapi.Data;
using RESTapi.Users;

namespace RESTapi.Crud
{
    public class CrudServices : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;

        public CrudServices(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        async public Task<User> CreateNewUserAsync(User user)
        {
            await _applicationContext.AddAsync(user);
            _applicationContext.SaveChanges();

            return user;
        }

        async public Task<User[]> GetAllUsersAsync()
        {
            var users = await _applicationContext.Users.ToArrayAsync();

            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _applicationContext.Users
                .FirstOrDefaultAsync(userId => userId.Id == id)
                ?? throw new Exception($"User id: {id} not found!");

            return user;
        }

        async public Task<User> UpdateUserAsync(User currectUser)
        {
            var newUser = await _applicationContext.Users
                .FirstOrDefaultAsync(userId => userId.Id == currectUser.Id)
                ?? throw new Exception($"User: {currectUser} is not found!");

            newUser.Email = currectUser.Email;

            return newUser;
        }

        async public Task<User> DeleteUserAsync(User user)
        {
            var userId = await _applicationContext.Users
                .FirstOrDefaultAsync(userId => userId.Id == user.Id)
                ?? throw new Exception($"User: {user} is not found");

            _applicationContext.Remove(userId);
            _applicationContext.SaveChanges();

            return userId;
        }
    }
}