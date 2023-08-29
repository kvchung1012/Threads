namespace Thread.Contract.IdentityService.Responses.Roles
{
    public class ApplicationRolePermissionResponse
    {
        public Guid Id { get; set; }

        public virtual Guid ApplicationRoleId { get; set; }

        public virtual Guid ApplicationPermissionId { get; set; }
    }
}
