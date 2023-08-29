using FluentValidation;
using Thread.Contract.IdentityService.Commands.Authentication.Login;

namespace Threads.IdentityService.Application.Features.Authentication.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("User name is empty");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password is empty");
        }
    }
}
