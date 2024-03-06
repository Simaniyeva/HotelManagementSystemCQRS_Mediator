namespace HotelAPI.Domain.Entities;

public class RoomImage : BaseEntity, IEntityBase
{
    public string FileName { get; set; }
    public string FilePath { get; set; }

    //Relations
    public int RoomId { get; set; }
    public Room Room { get; set; }
}

