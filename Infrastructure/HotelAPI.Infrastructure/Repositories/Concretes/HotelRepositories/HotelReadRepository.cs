namespace HotelAPI.Infrastructure.Repositories.Concretes.HotelRepositories;

public class HotelReadRepository : ReadRepository<Hotel>, IHotelReadRepository
{
    private readonly HotelIdentityDbContext _context;
    public HotelReadRepository(HotelIdentityDbContext context) : base(context)
    {

        _context = context;
    }
    public async Task<List<Hotel>> GetAllCityDetailsAsync(Expression<Func<Hotel, bool>>? exp = null)
    {

        return await _context.Hotels.Include(c => c.Rooms).ToListAsync();

    }
}
