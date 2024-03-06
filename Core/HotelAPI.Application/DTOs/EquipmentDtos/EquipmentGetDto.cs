using HotelAPI.Application.DTOs.RoomEquipmentDtos;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace HotelAPI.Application.DTOs.EquipmentDtos;

public class EquipmentGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public EquipmentCondition Condition { get; set; }

    //Relations
    public List<RoomEquipmentGetDto> RoomEquipments { get; set; } = new List<RoomEquipmentGetDto>();
}
