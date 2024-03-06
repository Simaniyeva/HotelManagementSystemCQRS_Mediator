using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.RoomEquipmentDtos;

public class RoomEquipmentGetDto:IDto, IMapTo<RoomEquipment>
{
    public int Id { get; set; }
    public RoomGetDto Room { get; set; }
    public EquipmentGetDto Equipment { get; set; }
}
