using Threads.BuildingBlock.Application.Cqrs.Commands;

namespace Thread.Contract.IdentityService.Commands.Authentication.Login
{
    public sealed record LoginCommand(string UserName, string Password) : ICommandResult<LoginCommand>;
}
