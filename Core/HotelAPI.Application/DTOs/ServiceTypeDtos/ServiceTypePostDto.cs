using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.ServiceTypeDtos;

public class ServiceTypePostDto : IDto, IMapTo<ServiceType>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
