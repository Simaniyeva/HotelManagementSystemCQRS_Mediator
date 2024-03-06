namespace HotelAPI.Domain.Entities;

public class Review:BaseEntity, IEntityBase
{
    public string Content { get; set; }
    public Rating Rating { get; set; }

    //Relations
    public int ReservatorId { get; set; }
    public Reservator Reservator { get; set; }
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
}
