using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threads.IdentityService.Domain.Entities;

namespace Threads.IdentityService.Infrastructure.Persistence.Configurations
{
    internal class ApplicationPermissionConfiguration : IEntityTypeConfiguration<ApplicationPermission>
    {
        public void Configure(EntityTypeBuilder<ApplicationPermission> builder)
        {
            builder.ToTable("ApplicationPermissions");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ParentPermission)
                .WithMany(x => x.ChildApplicationPermissions)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
