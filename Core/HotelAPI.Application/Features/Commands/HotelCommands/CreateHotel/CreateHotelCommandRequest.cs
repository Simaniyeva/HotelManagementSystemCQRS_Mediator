using HotelAPI.Application.DTOs.HotelImageDtos;

namespace HotelAPI.Application.Features.Commands.HotelCommands.CreateHotel;

public class CreateHotelCommandRequest : IRequest<CreateHotelCommandResponse>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string WebSite { get; set; }
    public Grade Grade { get; set; }

    //Relations
    public int CityId { get; set; }
    //hotelimage
    public List<HotelImagePostDto> HotelImages { get; set; }

}
