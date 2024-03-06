namespace HotelAPI.Domain.Repositories;

public interface IWriteRepository<TEntity> :IRepository<TEntity> where TEntity : BaseEntity, IEntityBase,new()
{
    Task CreateAsync(TEntity entity);
    Task CreateRangeAsync(List<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task DeleteAsync(int id);
    void DeleteRange(List<TEntity> entities);
    Task<int> SaveAsync();
}
