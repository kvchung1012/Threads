using Thread.Contract.IdentityService.Responses.Roles;
using Threads.BuildingBlock.Application.Cqrs.Queries;
using Threads.BuildingBlock.Application.Queries;

namespace Thread.Contract.IdentityService.Queries.RoleQueries.GetRoles;
public class GetRolesQuery : GetPaginationQuery, IQueryCollection<ApplicationRoleResponse>
{
    public string? SearchKey { get; set; }
    public string? Order { get; set; }
    public bool IsSortAsc { get; set; }
} 
