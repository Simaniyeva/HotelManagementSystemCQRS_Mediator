namespace HotelAPI.Infrastructure.Repositories.Concretes.HotelRepositories;

public class HotelWriteRepository : WriteRepository<Hotel>, IHotelWriteRepository
{
    public HotelWriteRepository(HotelIdentityDbContext context) : base(context) { }
}
