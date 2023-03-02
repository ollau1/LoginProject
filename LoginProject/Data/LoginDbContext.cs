using LoginProject.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace LoginProject.Data
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
