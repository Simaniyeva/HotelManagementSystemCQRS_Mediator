namespace HotelAPI.Application.DTOs.RoomDtos;

public class RoomPostDto : IDto, IMapTo<Room>
{
    public int Number { get; set; }
    public int Floor { get; set; }
    public string Phone { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public RoomState RoomState { get; set; }

    //Relations
    public int RoomTypeId { get; set; }
    public int HotelId { get; set; }
    public List<int>? EquipmentIds { get; set; }
    public List<RoomImagePostDto> RoomImages { get; set; }


}
