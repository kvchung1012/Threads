namespace Thread.Contract.IdentityService.Responses.Roles
{
    public class ApplicationRoleResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NormalizedName { get; set; } = string.Empty;
        public ICollection<ApplicationRolePermissionResponse>? RolePermissions { get; set; }
    }
}
