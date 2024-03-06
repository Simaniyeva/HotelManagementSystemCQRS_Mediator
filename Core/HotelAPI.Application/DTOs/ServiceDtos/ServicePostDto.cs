using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.ServiceDtos;

public class ServicePostDto : IDto, IMapTo<Service>
{
    public string Description { get; set; }
    public string AvailabilitySchedule { get; set; }
    public double Price { get; set; }
}

