using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.ServiceTypeDtos;

public class ServiceTypeUpdateDto : IDto, IMapTo<ServiceType>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}