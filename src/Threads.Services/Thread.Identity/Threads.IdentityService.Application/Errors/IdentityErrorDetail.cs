using Threads.IdentityService.Domain.Core.Primitives;

namespace Threads.IdentityService.Application.Errors
{
    public class IdentityErrorDetail
    {
        public static class ApplicationUserError
        {
            public static Error NotFound() => new("User.NotFound", "User was not found!");
        }
    }
}
