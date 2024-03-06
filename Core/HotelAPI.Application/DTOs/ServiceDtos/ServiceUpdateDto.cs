using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.ServiceDtos;

public class ServiceUpdateDto : IDto, IMapTo<Service>
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string AvailabilitySchedule { get; set; }
    public double Price { get; set; }
}

