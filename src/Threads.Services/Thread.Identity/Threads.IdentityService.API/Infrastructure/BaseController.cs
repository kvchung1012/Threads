using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threads.IdentityService.Domain.Core.Primitives;

namespace Threads.IdentityService.API.Infrastructure
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IActionResult OnSuccess(object value) => base.Ok(value);

        protected IActionResult OnFailure(Error error) => BadRequest(error);
    }
}
