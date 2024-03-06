namespace HotelAPI.Infrastructure.Repositories.Concretes.RoomImageRepositories;

public class RoomImageReadRepository : ReadRepository<RoomImage>, IRoomImageReadRepository
{
    public RoomImageReadRepository(HotelIdentityDbContext context) : base(context) { }
}
