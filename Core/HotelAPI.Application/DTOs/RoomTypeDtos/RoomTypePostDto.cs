using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.RoomTypeDtos;

public class RoomTypePostDto : IDto, IMapTo<RoomType>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
