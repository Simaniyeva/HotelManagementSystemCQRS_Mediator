namespace HotelAPI.Domain.Repositories;

public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, IEntityBase, new()
{
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? exp = null, params string[] includes);
    Task<List<TEntity>> GetAllPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>>? exp, params string[] includes);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, params string[] includes);
    Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> exp);
}
