using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.ReservatorDtos;

public class ReservatorUpdateDto : IDto, IMapTo<Reservator>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
