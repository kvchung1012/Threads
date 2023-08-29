using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ErrorOr;
using Threads.BuildingBlock.Application.Responses;
using Threads.BuildingBlock.Application.Persistences;

namespace Threads.BuildingBlock.Infrastructure.Repositories
{
    public class EfRepository<T> : ISqlRepository<T> where T : class
    {
        private readonly DbSet<T> _collections;
        public EfRepository(DbContext dbContext)
        {
            _collections = dbContext.Set<T>();
        }

        public async Task<long> CountByConditionAsync(Expression<Func<T, bool>>? conditionExpression = null, Func<IQueryable<T>, IQueryable<T>>? specialAction = null, CancellationToken token = default)
        {
            var fitler = _collections.Where(conditionExpression ?? (_ => true));
            var queryable = specialAction?.Invoke(fitler) ?? fitler;
            return await queryable.AsNoTracking().LongCountAsync(token);
        }

        public async Task<bool> ExistByConditionAsync(Expression<Func<T, bool>>? conditionExpression = null, CancellationToken token = default)
        {
            return await _collections.AsNoTracking().AnyAsync(conditionExpression ?? (_ => true), token);
        }

        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? conditionExpression = null, Func<IQueryable<T>, IQueryable<T>>? specialAction = null, CancellationToken cancellationToken = default)
        {
            var fitler = _collections.Where(conditionExpression ?? (_ => true));
            var queryable = specialAction?.Invoke(fitler) ?? fitler;
            return await queryable.AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginationResponse<T>> GetManyPaginationWithConditionAsync(Expression<Func<T, bool>>? conditionExpression = null, Func<IQueryable<T>, IQueryable<T>>? specialAction = null, CancellationToken cancellationToken = default)
        {
            var result = await GetManyWithConditionAsync(conditionExpression, specialAction, cancellationToken);
            var count = await CountByConditionAsync(conditionExpression, specialAction, cancellationToken);
            return new PaginationResponse<T>(result, count);
        }

        public async Task<List<T>> GetManyWithConditionAsync(Expression<Func<T, bool>>? conditionExpression = null, Func<IQueryable<T>, IQueryable<T>>? specialAction = null, CancellationToken cancellationToken = default)
        {
            var fitler = _collections.Where(conditionExpression ?? (_ => true));
            var queryable = specialAction?.Invoke(fitler) ?? fitler;
            return await queryable.AsNoTracking().ToListAsync(cancellationToken);
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>>? conditionExpression = null)
        {
            return conditionExpression is null ? _collections.AsQueryable() : _collections.Where(conditionExpression).AsQueryable();
        }

        public Task<IErrorOr> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorOr> CreateAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorOr> RemoveAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorOr> RemoveAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorOr> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorOr> UpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
