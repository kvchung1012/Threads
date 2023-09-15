using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Threads.BuildingBlock.Application.Cqrs.Queries.QueryFlow
{
    public interface IQueryListFlowBuilder<TModel, TResponse>
    {
        bool IsToModel { get; }
        bool IsEnablePaging { get; }
        int PageNumber { get; }
        int PageSize { get; }

        Expression<Func<TModel, bool>> Condition { get; }
        Func<IQueryable<TModel>, IOrderedQueryable<TModel>> OrderBy { get; }
        Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> Includes { get; }
        Func<IQueryable<TModel>, IQueryable<TModel>> SpecialActionToModel { get; }
        Func<IQueryable<TModel>, IQueryable<TResponse>> SpecialActionToResponse { get; }

        IQueryListFlowBuilder<TModel, TResponse> ApplyFilter(Expression<Func<TModel, bool>> condition);
        IQueryListFlowBuilder<TModel, TResponse> ApplyOrderBy(Func<IQueryable<TModel>, IOrderedQueryable<TModel>> OrderBy);
        IQueryListFlowBuilder<TModel, TResponse> ApplyPaging(int pageNumber, int pageSize);
        IQueryListFlowBuilder<TModel, TResponse> ApplyIncludes(Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> includes);
        IQueryListFlowBuilder<TModel, TResponse> ApplySpecialActionModel(Func<IQueryable<TModel>, IQueryable<TModel>> specialAction);
        IQueryListFlowBuilder<TModel, TResponse> ApplySpecialActionModel(Func<IQueryable<TModel>, IQueryable<TResponse>> specialAction);
    }
}
