using ErrorOr;
using MediatR;
using Threads.BuildingBlock.Application.Responses;

namespace Threads.BuildingBlock.Application.Cqrs.Queries
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, ErrorOr<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }

    public interface IQueryCollectionHandler<TQuery, TResponse> : IQueryHandler<TQuery, List<TResponse>>
        where TResponse : class
        where TQuery : IQueryCollection<TResponse>
    {
    }

    public interface IQueryPaginationHandler<TQuery, TResponse> : IQueryHandler<TQuery, PaginationResponse<TResponse>>
        where TQuery : IQueryPaged<TResponse>
        where TResponse : class
    {
    }

    public interface IQueryOneHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
        where TQuery : IQueryOne<TResponse>
    {
    }

    public interface IQueryCountHandler<TQuery> : IQueryHandler<TQuery, long>
       where TQuery : IQueryCounting
    {
    }
}
