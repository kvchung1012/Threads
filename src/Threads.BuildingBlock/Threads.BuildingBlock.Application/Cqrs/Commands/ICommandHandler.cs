using ErrorOr;
using MediatR;

namespace Threads.BuildingBlock.Application.Cqrs.Commands
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, IErrorOr>
      where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, ErrorOr<TResponse>>
       where TCommand : ICommandResult<TResponse>
    {
    }
}
