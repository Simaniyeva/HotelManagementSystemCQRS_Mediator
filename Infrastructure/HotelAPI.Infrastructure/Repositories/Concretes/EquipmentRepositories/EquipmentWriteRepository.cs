namespace HotelAPI.Infrastructure.Repositories.Concretes.EquipmentRepositories;

public class EquipmentWriteRepository : WriteRepository<Equipment>, IEquipmentWriteRepository
{
    public EquipmentWriteRepository(HotelIdentityDbContext context) : base(context) { }
}