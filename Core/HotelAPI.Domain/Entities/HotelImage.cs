namespace HotelAPI.Domain.Entities;

public class HotelImage:BaseEntity,IEntityBase
{
    public string FileName { get; set; }
    public string FilePath { get; set; }

    //Relations
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
}

