namespace Threads.IdentityService.Domain.Entities
{
    public class ApplicationRolePermission
    {
        public Guid Id { get; set; }

        public virtual Guid ApplicationRoleId { get; set; }

        public virtual ApplicationRole? Role { get; set; }

        public virtual Guid ApplicationPermissionId { get; set; }

        public virtual ApplicationPermission? Permission { get; set; }
    }
}
