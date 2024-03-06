namespace HotelAPI.Domain.Entities;

public class RoomEquipment : BaseEntity, IEntityBase
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; }


}

