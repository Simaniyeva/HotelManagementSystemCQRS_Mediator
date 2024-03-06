namespace HotelAPI.Infrastructure.Repositories.Concretes.RoomTypeRepositories;
public class RoomTypeReadRepository : ReadRepository<RoomType>, IRoomTypeReadRepository
{
    public RoomTypeReadRepository(HotelIdentityDbContext context) : base(context) { }
}

