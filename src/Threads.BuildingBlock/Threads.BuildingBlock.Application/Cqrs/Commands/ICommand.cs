using ErrorOr;
using MediatR;

namespace Threads.BuildingBlock.Application.Cqrs.Commands
{
    /// <summary>
    /// Dùng cho các command không cần dữ liệu trả về
    /// </summary>
    public interface ICommand : IRequest<IErrorOr>
    {
    }

    /// <summary>
    /// Dùng cho các command có dữ liệu trả về
    /// </summary>
    /// <typeparam name="TResponse">Kiểu dữ liêụ trả về</typeparam>
    public interface ICommandResult<TResponse> : IRequest<ErrorOr<TResponse>>
    {
    }
}
