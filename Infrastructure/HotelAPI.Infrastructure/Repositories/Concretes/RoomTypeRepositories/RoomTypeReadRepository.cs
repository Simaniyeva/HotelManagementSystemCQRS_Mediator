namespace HotelAPI.Infrastructure.Repositories.Concretes.RoomTypeRepositories;
public class RoomTypeReadRepository : ReadRepository<RoomType>, IRoomTypeReadRepository
{
    private readonly HotelIdentityDbContext _context;

    public RoomTypeReadRepository(HotelIdentityDbContext context) : base(context) {
    _context = context;
    }

    public async Task<List<RoomType>> GetAllRoomTypesDetailsAsync(Expression<Func<RoomType, bool>>? exp = null)
    {

            return await _context.RoomTypes.Include(c => c.Rooms).ToListAsync();
        
    }
}

