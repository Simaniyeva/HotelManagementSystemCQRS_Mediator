
namespace HotelAPI.Application.DTOs.HotelDtos;

public class HotelGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string WebSite { get; set; }
    public Grade Grade { get; set; }
    public bool isActive { get; set; }
    public decimal TotalRating { get; set; }


    //Relations
    public CityGetDto City { get; set; }
    public List<ReviewGetDto> Reviews { get; set; }
    public List<RoomGetDto> Rooms { get; set; }
    public List<HotelImage> HotelImages { get; set; }

}
