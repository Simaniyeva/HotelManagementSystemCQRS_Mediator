using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.ReservationDtos;

public class ReservationPostDto : IDto, IMapTo<Reservation>
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; } = ReservationStatus.Pending;
    //Relations
    public int RoomId { get; set; }
    public int ReservatorId { get; set; }
}
