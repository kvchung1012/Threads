using ErrorOr;
using Thread.Contract.IdentityService.Commands.Authentication.Login;
using Threads.BuildingBlock.Application.Cqrs.Commands;
using Threads.BuildingBlock.Application.Persistences;
using Threads.IdentityService.Domain.Entities;

namespace Threads.IdentityService.Application.Features.Authentication.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommand>
    {
        private readonly ISqlRepository<ApplicationUser> _sqlRepository;
        public LoginCommandHandler(ISqlRepository<ApplicationUser> sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task<ErrorOr<LoginCommand>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var list = _sqlRepository.GetQueryable().Select(x => new { x.UserName, x.PasswordHash }).ToList();
            if (request.UserName == "admin")
                return Error.NotFound();

            return await Task.FromResult(request);
        }
    }
}
