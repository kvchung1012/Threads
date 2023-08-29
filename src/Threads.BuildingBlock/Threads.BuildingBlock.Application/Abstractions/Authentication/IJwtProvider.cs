namespace Threads.BuildingBlock.Application.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        Task<string> GenarateToken();
    }
}
