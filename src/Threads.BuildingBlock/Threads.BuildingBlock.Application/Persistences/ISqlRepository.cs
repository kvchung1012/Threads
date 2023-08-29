using ErrorOr;
using System.Linq.Expressions;
using Threads.BuildingBlock.Application.Responses;

namespace Threads.BuildingBlock.Application.Persistences
{
    public interface ISqlRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Lấy dữ liệu với điều kiện
        /// </summary>
        /// <param name="conditionExpression"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>>? conditionExpression = null);

        /// <summary>
        /// Query the first record with condition
        /// </summary>
        /// <param name="conditionExpression"></param>
        /// <returns></returns>
        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? conditionExpression = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? specialAction = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query data with condition
        /// </summary>
        /// <param name="conditionExpression"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetManyWithConditionAsync(Expression<Func<TEntity, bool>>? conditionExpression = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? specialAction = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query data with pagination
        /// </summary>
        /// <param name="conditionExpression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PaginationResponse<TEntity>> GetManyPaginationWithConditionAsync(Expression<Func<TEntity, bool>>? conditionExpression = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? specialAction = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query count data
        /// </summary>
        /// <param name="conditionExpression"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<long> CountByConditionAsync(Expression<Func<TEntity, bool>>? conditionExpression = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? specialAction = null, CancellationToken token = default);

        /// <summary>
        /// Check data is exists
        /// </summary>
        /// <param name="conditionExpression"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> ExistByConditionAsync(Expression<Func<TEntity, bool>>? conditionExpression = null, CancellationToken token = default);

        /// <summary>
        /// Tạo mới một đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IErrorOr> CreateAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Tạo mới nhiều đối tượng
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IErrorOr> CreateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        /// <summary>
        /// Cập nhật một đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IErrorOr> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Cập nhật nhiều đối tượng
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IErrorOr> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        /// <summary>
        /// Xóa một đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IErrorOr> RemoveAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IErrorOr> RemoveAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    }
}
