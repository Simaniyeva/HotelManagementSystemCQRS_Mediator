using HotelAPI.Domain.Repositories.RoomEquipmentRepositories;

namespace HotelAPI.Infrastructure.Repositories.Concretes.RoomEquipmentRepositories;

public class RoomEquipmentReadRepository : ReadRepository<RoomEquipment>, IRoomEquipmentReadRepository
{
    public RoomEquipmentReadRepository(HotelIdentityDbContext context) : base(context) { }
}




