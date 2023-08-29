using MediatR;
using Microsoft.AspNetCore.Mvc;
using Thread.Contract.IdentityService.Commands.Authentication.Login;
using Thread.Contract.IdentityService.Queries.RoleQueries.GetRoles;
using Threads.IdentityService.API.Infrastructure;
using Threads.IdentityService.Domain.Primitives.Result;

namespace Threads.IdentityService.API.Controllers
{
    public sealed class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(loginCommand, cancellationToken);
            return result.Match(OnSuccess, BadRequest);
        }

        [HttpPost("get-roles")]
        public async Task<IActionResult> GetRoleAsync([FromQuery] GetRolesQuery getRolesQuery, CancellationToken cancellationToken) =>
            (await Mediator.Send(getRolesQuery, cancellationToken))
                   .Match(OnSuccess, BadRequest);
    }
}
