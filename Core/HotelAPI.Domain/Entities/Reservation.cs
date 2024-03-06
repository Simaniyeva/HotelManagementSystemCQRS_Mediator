namespace HotelAPI.Domain.Entities;

public class Reservation:BaseEntity, IEntityBase
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; } = ReservationStatus.Pending;
    //Relations
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public int ReservatorId { get; set; }
    public Reservator Reservator { get; set; }
}
