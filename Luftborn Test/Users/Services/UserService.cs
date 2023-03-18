using Luftborn_Test.Data;
using Luftborn_Test.Users.Interfaces;
using Luftborn_Test.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Luftborn_Test.Users.Services
{
    public class UserService : IUserService
    {
        readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if(user == null)
            {
                return false;
            }

            user.IsDeleted = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.Where(s => !s.IsDeleted).ToListAsync();
            return users;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
