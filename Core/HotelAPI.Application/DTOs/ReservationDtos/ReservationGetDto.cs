namespace HotelAPI.Application.DTOs.ReservationDtos;

public class ReservationGetDto:IDto
{
    public int Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; } = ReservationStatus.Pending;
    //Relations
    public RoomGetDto Room { get; set; }
    public ReservatorGetDto Reservator { get; set; }
}
