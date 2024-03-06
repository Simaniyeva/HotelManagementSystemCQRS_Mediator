namespace HotelAPI.Domain.Entities;

public class RoomType:BaseEntity, IEntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    //Relations
    public virtual List<Room>Rooms { get; set; }

}
