namespace HotelAPI.Domain.Repositories;

public interface IRepository<TEntity>where TEntity : BaseEntity, IEntityBase, new()
{
}
