using RESTapi.Crud;
using RESTapi.Users;

namespace RESTapi.Controllers
{
    public class AppControllers
    {
        private CrudServices _services;

        public AppControllers(CrudServices services)
        {
            _services = services;
        }

        async public Task<User[]> GetAllUsersController()
        {
            var users = await _services.GetAllUsersAsync();

            return users;
        }

        async public Task<User> GetUserByIdController(int id)
        {
            var user = await _services.GetUserByIdAsync(id);

            return user;
        }

        async public Task<User> UpdateUserController(User user)
        {
            var newUser = await _services.UpdateUserAsync(user);

            return newUser;
        }

        async public Task<User> AddUserController(User user)
        {
            var newUser = await _services.CreateNewUserAsync(user);

            return newUser;
        }

        async public Task<User> DeleteUserController(User currentUser)
        {
            var user = await _services.DeleteUserAsync(currentUser);

            return user;
        }
    }
}