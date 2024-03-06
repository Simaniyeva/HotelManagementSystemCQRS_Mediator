namespace HotelAPI.Infrastructure.Repositories.Concretes.HotelRepositories;

public class HotelReadRepository : ReadRepository<Hotel>, IHotelReadRepository
{
    public HotelReadRepository(HotelIdentityDbContext context) : base(context) { }
}
