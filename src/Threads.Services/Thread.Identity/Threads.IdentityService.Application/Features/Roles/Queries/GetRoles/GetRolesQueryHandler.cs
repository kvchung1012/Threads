using AutoMapper;
using AutoMapper.QueryableExtensions;
using Serilog;
using Thread.Contract.IdentityService.Queries.RoleQueries.GetRoles;
using Thread.Contract.IdentityService.Responses.Roles;
using Threads.BuildingBlock.Application.Cqrs.EntityFramework.EfQuery;
using Threads.BuildingBlock.Application.Cqrs.Queries.QueryFlow;
using Threads.BuildingBlock.Application.Persistences;
using Threads.IdentityService.Domain.Entities;
namespace Threads.IdentityService.Application.Features.Roles.Queries.GetRoles
{
    public class GetRolesQueryHandler : EfCollectionHandler<ApplicationRole, GetRolesQuery, ApplicationRoleResponse>
    {
        public GetRolesQueryHandler(ISqlRepository<ApplicationRole> sqlRepository, IMapper mapper, ILogger logger)
            : base(sqlRepository, logger, mapper)
        {

        }

        protected override IQueryListFlowBuilder<ApplicationRole, ApplicationRoleResponse> BuildQueryFlow(IQueryListFlowBuilder<ApplicationRole, ApplicationRoleResponse> queryFlow, GetRolesQuery query)
            => queryFlow
                .ApplyFilter(x => x.Name.Contains(query.SearchKey ?? ""))
                .ApplyOrderBy(x => x.OrderBy(x => x.NormalizedName))
                .ApplySpecialActionModel(queryable
                    => queryable.ProjectTo<ApplicationRoleResponse>(_mapper.ConfigurationProvider));
    }
}
