namespace HotelAPI.Infrastructure.Repositories.Concretes.EquipmentRepositories;

public class EquipmentReadRepository : ReadRepository<Equipment>, IEquipmentReadRepository
{
    public EquipmentReadRepository(HotelIdentityDbContext context) : base(context) { }
}
