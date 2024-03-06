using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.EquipmentDtos;

public class EquipmentPostDto : IDto, IMapTo<Equipment>
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}
