namespace HotelAPI.Infrastructure.Repositories.Concretes.ServiceTypeRepositories;

public class ServiceTypeReadRepository : ReadRepository<ServiceType>, IServiceTypeReadRepository
{
    public ServiceTypeReadRepository(HotelIdentityDbContext context) : base(context) { }
}
