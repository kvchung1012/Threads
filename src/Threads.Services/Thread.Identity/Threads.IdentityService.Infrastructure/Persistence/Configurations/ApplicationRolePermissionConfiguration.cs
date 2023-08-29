using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threads.IdentityService.Domain.Entities;

namespace Threads.IdentityService.Infrastructure.Persistence.Configurations
{
    internal sealed class ApplicationRolePermissionConfiguration : IEntityTypeConfiguration<ApplicationRolePermission>
    {
        public void Configure(EntityTypeBuilder<ApplicationRolePermission> builder)
        {
            builder.ToTable("ApplicationRolePermissions");

            builder.HasKey(x => x.Id);

            builder.HasOne<ApplicationRole>()
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x=>x.ApplicationRoleId);

            builder.HasOne<ApplicationPermission>()
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.ApplicationPermissionId);
        }
    }
}
