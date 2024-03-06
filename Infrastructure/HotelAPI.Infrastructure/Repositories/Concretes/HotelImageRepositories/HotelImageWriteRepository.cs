using HotelAPI.Domain.Repositories.HotelImageRepositories;

namespace HotelAPI.Infrastructure.Repositories.Concretes.HotelImageRepositories;

public class RoomImageWriteRepository : WriteRepository<HotelImage>, IHotelImageWriteRepository
{
    public RoomImageWriteRepository(HotelIdentityDbContext context) : base(context) { }
}
