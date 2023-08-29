using ErrorOr;
using MediatR;
using Threads.BuildingBlock.Application.Responses;

namespace Threads.BuildingBlock.Application.Cqrs.Queries
{
    public interface IQuery<TResult> : IRequest<ErrorOr<TResult>>
    {
    }

    /// <summary>
    /// Dùng cho query count
    /// </summary>
    public interface IQueryCounting : IQuery<long>
    {
    }

    /// <summary>
    /// Dùng cho query 1 bản ghi
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IQueryOne<TResult> : IQuery<TResult>
    {
    }

    /// <summary>
    /// Dùng cho query phân trang
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IQueryPaged<TResult> : IQuery<PaginationResponse<TResult>> where TResult : class
    {
    }

    /// <summary>
    /// Dùng cho query list
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IQueryCollection<TResult> : IQuery<List<TResult>> where TResult : class
    {
    }
}
