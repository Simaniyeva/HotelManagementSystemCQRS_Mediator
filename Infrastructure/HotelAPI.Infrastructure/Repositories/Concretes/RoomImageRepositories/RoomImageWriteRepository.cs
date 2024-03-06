
namespace HotelAPI.Infrastructure.Repositories.Concretes.RoomImageRepositories;

public class RoomImageWriteRepository : WriteRepository<RoomImage>, IRoomImageWriteRepository
{
    public RoomImageWriteRepository(HotelIdentityDbContext context) : base(context) { }
}
