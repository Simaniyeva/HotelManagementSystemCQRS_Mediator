using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.RoomEquipmentDtos;

public class RoomEquipmentUpdateDto : IDto, IMapTo<RoomEquipment>
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int EquipmentId { get; set; }
}