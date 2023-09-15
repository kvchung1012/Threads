namespace Thread.Contract.IdentityService.Responses.Roles
{
    public class ApplicationRolePermissionResponse
    {
        public Guid Id { get; set; }

        public Guid ApplicationRoleId { get; set; }

        public Guid ApplicationPermissionId { get; set; }
    }
}
