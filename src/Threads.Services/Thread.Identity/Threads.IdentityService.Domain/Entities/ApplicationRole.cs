using Microsoft.AspNetCore.Identity;

namespace Threads.IdentityService.Domain.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public virtual ICollection<ApplicationRolePermission>? RolePermissions { get; set; }
    }
}
