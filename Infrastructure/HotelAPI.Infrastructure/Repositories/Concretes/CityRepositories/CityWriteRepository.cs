
namespace HotelAPI.Infrastructure.Repositories.Concretes.CityRepositories;

public class CityWriteRepository : WriteRepository<City>, ICityWriteRepository
{
    public CityWriteRepository(HotelIdentityDbContext context) : base(context) { }
}
