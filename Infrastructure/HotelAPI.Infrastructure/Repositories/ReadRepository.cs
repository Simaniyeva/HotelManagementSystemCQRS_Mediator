namespace HotelAPI.Infrastructure.Repositories;

public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity, IEntityBase, new()
{
    private readonly HotelIdentityDbContext _context;

    public ReadRepository(HotelIdentityDbContext context)
    {
        _context = context;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? exp = null, params string[] includes)
    {
        return exp is null
            ? await GetQuery(includes).AsNoTracking().ToListAsync()
            : await GetQuery(includes).Where(exp).AsNoTracking().ToListAsync();

    }

    public async Task<List<TEntity>> GetAllPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>>? exp, params string[] includes)
    {
        return exp is null
                        ? await GetQuery(includes).Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync()
                        : await GetQuery(includes).Skip((page - 1) * size).Take(size).Where(exp).AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
    {
        return await GetQuery(includes).Where(exp).AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> exp)
    {
        return await _context.Set<TEntity>().AnyAsync(exp);
    }


    #region PrivateMethods
    private IQueryable<TEntity> GetQuery(string[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        if (includes is not null)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }
    #endregion
}

