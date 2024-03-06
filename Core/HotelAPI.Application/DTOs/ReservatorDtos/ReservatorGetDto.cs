namespace HotelAPI.Application.DTOs.ReservatorDtos;

public class ReservatorGetDto:IDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    //Relations
    public List<ReservationGetDto> Reservations { get; set; }
    public List<ReviewGetDto> Reviews { get; set; }
}
