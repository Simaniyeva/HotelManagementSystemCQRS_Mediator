
namespace HotelAPI.Application.DTOs.RoomDtos;

public class RoomGetDto:IDto
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public string Phone { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public RoomState RoomState { get; set; }
    public List<EquipmentGetDto> Equipments { get; set; }

    //Relations
    public RoomTypeGetDto RoomType { get; set; }
    public HotelGetDto Hotel { get; set; }
    public List<ReservationGetDto> Reservations { get; set; }
    public List<RoomEquipmentGetDto>RoomEquipments { get; set; }=  new List<RoomEquipmentGetDto>();
    public List<RoomImage> RoomImages { get; set; }

}
