using Luftborn_Test.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Luftborn_Test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
