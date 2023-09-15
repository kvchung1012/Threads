using AutoMapper;
using AutoMapper.QueryableExtensions;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Threads.BuildingBlock.Application.Cqrs.Queries;
using Threads.BuildingBlock.Application.Cqrs.Queries.QueryFlow;
using Threads.BuildingBlock.Application.Persistences;

namespace Threads.BuildingBlock.Application.Cqrs.EntityFramework.EfQuery
{
    public abstract class EfCollectionHandler<TEntity, TQuery, TResponse> : IQueryCollectionHandler<TQuery, TResponse>
        where TEntity : class
        where TQuery : IQueryCollection<TResponse>
        where TResponse : class

    {
        private readonly ISqlRepository<TEntity> _sqlRepository;
        private readonly IQueryListFlowBuilder<TEntity, TResponse> _queryListFlowBuilder;
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;
        protected EfCollectionHandler(ISqlRepository<TEntity> sqlRepository, ILogger logger, IMapper mapper)
        {
            _logger = logger;
            _sqlRepository = sqlRepository;
            _mapper = mapper;
            _queryListFlowBuilder = new QueryListFlow<TEntity, TResponse>();
        }

        /// <summary>
        /// Excute query
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<ErrorOr<List<TResponse>>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            _logger.Information("Get many for {@RequestType}: {@Request}", request.GetType().Name, request);

            var flowBuilder = BuildQueryFlow(_queryListFlowBuilder, request);

            if (flowBuilder.IsToModel)
            {
                var result = await _sqlRepository
                    .GetManyWithConditionAsync(flowBuilder.Condition, db =>
                    {
                        var queryable = flowBuilder.SpecialActionToModel?.Invoke(db) ?? db;

                        if (flowBuilder.OrderBy is not null)
                            queryable = flowBuilder.OrderBy(queryable);

                        queryable.ProjectTo<TResponse>(_mapper.ConfigurationProvider);
                        return queryable;

                    }, cancellationToken);

                return _mapper.Map<List<TResponse>>(result);
            }

            else
            {
                var queryable = _sqlRepository.GetQueryable(flowBuilder.Condition).AsNoTracking();

                if (flowBuilder.OrderBy is not null)
                    queryable = flowBuilder.OrderBy(queryable);

                return (flowBuilder.SpecialActionToResponse?.Invoke(queryable)
                    ?? queryable.ProjectTo<TResponse>(_mapper.ConfigurationProvider)).ToList();
            }
        }

        /// <summary>
        /// Dùng để publish event, caching...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual Task AfterQueryAsync(TQuery request, CancellationToken cancellationToken)
            => Task.CompletedTask;

        /// <summary>
        /// Build câu query filter, sắp xếp, select...
        /// </summary>
        /// <param name="queryFlow"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        protected abstract IQueryListFlowBuilder<TEntity, TResponse> BuildQueryFlow(
                IQueryListFlowBuilder<TEntity, TResponse> queryFlow, TQuery query);
    }
}
