using ErrorOr;

namespace Threads.BuildingBlock.Application.Persistences
{
    public interface IUnitOfWork
    {
        Task<IErrorOr> SaveChangeAsync();
    }
}
