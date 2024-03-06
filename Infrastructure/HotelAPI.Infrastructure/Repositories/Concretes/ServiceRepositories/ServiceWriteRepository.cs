namespace HotelAPI.Infrastructure.Repositories.Concretes.ServiceRepositories;

public class ServiceWriteRepository : WriteRepository<Service>, IServiceWriteRepository
{
    public ServiceWriteRepository(HotelIdentityDbContext context) : base(context) { }
}

