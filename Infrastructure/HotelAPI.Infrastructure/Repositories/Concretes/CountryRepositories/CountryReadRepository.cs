
namespace HotelAPI.Infrastructure.Repositories.Concretes.CountryRepositories;

public class CountryReadRepository : ReadRepository<Country>, ICountryReadRepository
{
    private readonly HotelIdentityDbContext _context;

    public CountryReadRepository(HotelIdentityDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Country>> GetAllDetailsOfCountries(Expression<Func<Country, bool>>? exp = null)
    {
        return await _context.Countries
            .Include(c => c.Cities)
            .ThenInclude(c => c.Hotels)
            .ToListAsync();

    }
}
