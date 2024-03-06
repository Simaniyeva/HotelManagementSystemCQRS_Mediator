
namespace HotelAPI.Infrastructure.Repositories.Concretes.CityRepositories;

public class CityReadRepository : ReadRepository<City>, ICityReadRepository
{
    private readonly HotelIdentityDbContext _context;

    public CityReadRepository(HotelIdentityDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<City>> GetAllCityDetailsAsync(Expression<Func<City, bool>>? exp = null)
    {
        return await _context.Cities.Include(c => c.Hotels).ToListAsync();
    }
}
