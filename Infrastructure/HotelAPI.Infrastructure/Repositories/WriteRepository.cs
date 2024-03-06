using HotelAPI.Persistence.DbContexts;

namespace HotelAPI.Infrastructure.Repositories;

public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity, IEntityBase, new()
{
    private readonly HotelIdentityDbContext _context;

    public WriteRepository(HotelIdentityDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);

    }

    public async Task CreateRangeAsync(List<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);

    }

    public async Task DeleteAsync(int id)
    {
        TEntity model = await _context.Set<TEntity>().FirstOrDefaultAsync(b => b.Id == id);
        Delete(model);
    }

    public void DeleteRange(List<TEntity> entities)
    {
        _context.RemoveRange(entities);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Update(TEntity entity)
    {
        _context.ChangeTracker.Clear();
        _context.Set<TEntity>().Update(entity);
    }
}
