using AutoMapper;
using ErrorOr;
using Serilog;
using System.Linq.Expressions;
using Threads.BuildingBlock.Application.Cqrs.Queries;
using Threads.BuildingBlock.Application.Persistences;

namespace Threads.BuildingBlock.Application.Cqrs.EntityFramework.EfQuery
{
    public abstract class EfCollectionHandler<TEntity, TQuery, TResponse> : IQueryCollectionHandler<TQuery, TResponse>
        where TEntity : class
        where TQuery : IQueryCollection<TResponse>
        where TResponse : class

    {
        private readonly ISqlRepository<TEntity> _sqlRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        protected EfCollectionHandler(ISqlRepository<TEntity> sqlRepository, ILogger logger, IMapper mapper)
        {
            _logger = logger;
            _sqlRepository = sqlRepository;
            _mapper = mapper;
        }

        public virtual async Task<ErrorOr<List<TResponse>>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            _logger.Information("Get many for {@RequestType}: {@Request}", request.GetType().Name, request);

            var filter = BuildFilterQuery(request);
            var specialAction = BuildSpecialAction();
            var queryable = await _sqlRepository.GetManyWithConditionAsync(filter, specialAction, cancellationToken);

            return _mapper.Map<List<TResponse>>(queryable);
        }

        /// <summary>
        /// Dùng để publish event, caching...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual Task AfterQueryAsync(TQuery request, CancellationToken cancellationToken)
        => Task.CompletedTask;

        protected abstract Expression<Func<TEntity, bool>> BuildFilterQuery(TQuery request);

        protected abstract Func<IQueryable<TEntity>, IQueryable<TEntity>> BuildSpecialAction();
    }
}
