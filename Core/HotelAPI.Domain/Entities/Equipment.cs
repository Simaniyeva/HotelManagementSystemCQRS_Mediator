namespace HotelAPI.Domain.Entities;

public class Equipment:BaseEntity, IEntityBase
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public EquipmentCondition Condition { get; set; } = EquipmentCondition.Good;

    //Relations
    public List<RoomEquipment> RoomEquipments { get; set; }

}
