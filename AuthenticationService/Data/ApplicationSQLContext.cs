using AuthenticationService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Data
{
    public class ApplicationSQLContext : DbContext
    {
        public ApplicationSQLContext(DbContextOptions<ApplicationSQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }
        public DbSet<UserMatrix> UserMatrices { get; set; }
    }
}
