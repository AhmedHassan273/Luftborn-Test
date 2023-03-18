using Luftborn_Test.Users.Models;

namespace Luftborn_Test.Users.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> AddUserAsync(User user);
    }
}
