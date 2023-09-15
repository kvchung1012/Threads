using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Threads.BuildingBlock.Application.Cqrs.Queries.QueryFlow
{
    public class QueryListFlow<TModel, TResponse> : IQueryListFlowBuilder<TModel, TResponse>
    {
        public QueryListFlow()
        {
            Condition = x => true;
        }

        public bool IsToModel { get; private set; } = true;
        public bool IsPaging { get; private set; }
        public Expression<Func<TModel, bool>> Condition { get; private set; } = default!;
        public Func<IQueryable<TModel>, IQueryable<TModel>> SpecialActionToModel { get; private set; } = default!;
        public Func<IQueryable<TModel>, IQueryable<TResponse>> SpecialActionToResponse { get; private set; } = default!;
        public Func<IQueryable<TModel>, IOrderedQueryable<TModel>> OrderBy { get; private set; } = default!;
        public Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> Includes { get; private set; } = default!;
        public bool IsEnablePaging { get; private set; } = false;

        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }


        public IQueryListFlowBuilder<TModel, TResponse> ApplyFilter(Expression<Func<TModel, bool>> condition)
        {
            Condition = condition;
            return this;
        }

        public IQueryListFlowBuilder<TModel, TResponse> ApplyIncludes(Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> includes)
        {
            Includes = includes;
            return this;
        }

        public IQueryListFlowBuilder<TModel, TResponse> ApplyOrderBy(Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy)
        {
            OrderBy = orderBy;
            return this;
        }

        public IQueryListFlowBuilder<TModel, TResponse> ApplyPaging(int pageNumber, int pageSize)
        {
            IsEnablePaging = true;
            PageSize = pageSize;
            PageNumber = pageNumber;
            return this;
        }

        //public IQueryListFlowBuilder<TModel, TResponse> ApplyProjectionTo<TRes>()
        //{
        //    //SpecialActionToModel.
        //}

        public IQueryListFlowBuilder<TModel, TResponse> ApplySpecialActionModel(Func<IQueryable<TModel>, IQueryable<TModel>> specialAction)
        {
            IsToModel = true;
            SpecialActionToModel = specialAction;
            return this;
        }

        public IQueryListFlowBuilder<TModel, TResponse> ApplySpecialActionModel(Func<IQueryable<TModel>, IQueryable<TResponse>> specialAction)
        {
            IsToModel = false;
            SpecialActionToResponse = specialAction;
            return this;
        }
    }
}
