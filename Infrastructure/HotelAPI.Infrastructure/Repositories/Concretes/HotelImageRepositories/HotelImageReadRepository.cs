using HotelAPI.Domain.Repositories.HotelImageRepositories;

namespace HotelAPI.Infrastructure.Repositories.Concretes.HotelImageRepositories;

public class HotelImageReadRepository : ReadRepository<HotelImage>, IHotelImageReadRepository
{
    public HotelImageReadRepository(HotelIdentityDbContext context) : base(context) { }
}
