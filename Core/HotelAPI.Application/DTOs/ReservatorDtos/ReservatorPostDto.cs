using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.ReservatorDtos;

public class ReservatorPostDto: IDto, IMapTo<Reservator>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
