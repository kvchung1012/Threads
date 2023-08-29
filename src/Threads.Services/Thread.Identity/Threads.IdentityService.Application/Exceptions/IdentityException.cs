namespace Threads.IdentityService.Application.Exceptions
{
    public class IdentityException : Exception
    {
        public IdentityException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
