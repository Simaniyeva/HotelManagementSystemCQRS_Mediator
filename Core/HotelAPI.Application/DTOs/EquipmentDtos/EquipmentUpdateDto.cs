using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.EquipmentDtos;

public class EquipmentUpdateDto : IDto, IMapTo<Equipment>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}
