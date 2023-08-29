using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;
using Thread.Contract.IdentityService.Queries.RoleQueries.GetRoles;
using Thread.Contract.IdentityService.Responses.Roles;
using Threads.BuildingBlock.Application.Cqrs.EntityFramework.EfQuery;
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

        protected override Expression<Func<ApplicationRole, bool>> BuildFilterQuery(GetRolesQuery request)
        {
            Expression<Func<ApplicationRole, bool>> expression = request?.SearchKey switch
            {
                { } val => applicationRole => request.SearchKey.Contains(applicationRole.Name ?? ""),
                _ => _ => true
            };

            return expression;
        }

        protected override Func<IQueryable<ApplicationRole>, IQueryable<ApplicationRole>> BuildSpecialAction()
        {
            return queryable => queryable.Include(x => x.RolePermissions);
        }
    }
}
