namespace Threads.IdentityService.Domain.Core.Primitives;

public sealed class Error
{
    public string Code { get; set; }
    public string Message { get; set; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error None => new(string.Empty, string.Empty);

    public static Error NotFound => new("NotFound", "Your requested resource was not found");

    public static Error Failure => new("Failure", "An error occurred during processing");
}
