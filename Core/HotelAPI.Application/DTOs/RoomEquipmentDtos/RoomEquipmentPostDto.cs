using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.RoomEquipmentDtos;

public class RoomEquipmentPostDto : IDto, IMapTo<RoomEquipment>
{

    public int RoomId { get; set; }
    public int EquipmentId { get; set; }
}