using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ST10040092_Nikhil_POE_Part2_PROG6212.Models;

namespace ST10040092_Nikhil_POE_Part2_PROG6212.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

      
        public DbSet<User> User { get; set; }

        public DbSet<Claim> Claims { get; set; }
      
    }
}
