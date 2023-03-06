using authentication.back.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace authentication.back.Models
{
    public class AuthenticationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
            : base(options) {}
    }
}
