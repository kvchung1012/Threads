using Threads.IdentityService.Domain.Core.Primitives;

namespace Threads.IdentityService.Domain.Entities
{
    public class ApplicationPermission : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsGrantedByDefault { get; set; }
        public Guid? ParentId { get; set; }
        public virtual ApplicationPermission? ParentPermission { get; set; }
        public virtual ICollection<ApplicationPermission>? ChildApplicationPermissions { get; set; }
        public virtual ICollection<ApplicationRolePermission>? RolePermissions { get; set; }
    }
}
