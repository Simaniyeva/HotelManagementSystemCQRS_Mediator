using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.RoomTypeDtos;

public class RoomTypeUpdateDto : IDto, IMapTo<RoomType>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
