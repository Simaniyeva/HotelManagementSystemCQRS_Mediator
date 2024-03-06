using HotelAPI.Domain.Repositories.RoomEquipmentRepositories;

namespace HotelAPI.Infrastructure.Repositories.Concretes.RoomEquipmentRepositories;

public class RoomEquipmentWriteRepository : WriteRepository<RoomEquipment>, IRoomEquipmentWriteRepository
{
    public RoomEquipmentWriteRepository(HotelIdentityDbContext context) : base(context) { }
}




