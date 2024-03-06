namespace HotelAPI.Infrastructure.Repositories.Concretes.ServiceRepositories;
public class ServiceReadRepository : ReadRepository<Service>, IServiceReadRepository
{
    public ServiceReadRepository(HotelIdentityDbContext context) : base(context) { }
}

