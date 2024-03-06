namespace HotelAPI.Application.DTOs.RoomTypeDtos;

public class RoomTypeGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //Relations
    public List<RoomGetDto>Rooms { get; set; }

}
