using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AAASecurity.Models
{
    public class AAADbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<BadPassword> BadPasswords { get; set; }

        public AAADbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BadPassword>().HasKey(e => e.Id);
        }
    }
}
