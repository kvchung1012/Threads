using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Threads.IdentityService.Domain.Entities;

namespace Threads.IdentityService.Infrastructure.Persistence
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationUserClaim> ApplicationUserClaims { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<ApplicationRoleClaim> ApplicationRoleClaims { get; set; }

        public DbSet<ApplicationPermission> ApplicationPermissions { get; set; }

        public DbSet<ApplicationPermission> ApplicationRolePermissions { get; set; }

        public DbSet<ApplicationUserLogin> ApplicationUserLogins { get; set; }

        public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }
    }
}
