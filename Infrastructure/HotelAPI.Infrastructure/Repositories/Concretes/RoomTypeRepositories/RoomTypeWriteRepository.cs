namespace HotelAPI.Infrastructure.Repositories.Concretes.RoomTypeRepositories;

public class RoomTypeWriteRepository : WriteRepository<RoomType>, IRoomTypeWriteRepository
{
    public RoomTypeWriteRepository(HotelIdentityDbContext context) : base(context) { }
}

