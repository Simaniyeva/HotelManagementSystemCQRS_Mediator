namespace HotelAPI.Application.DTOs.ServiceTypeDtos;

public class ServiceTypeGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //Relations
    public List<ServiceGetDto> Services { get; set; }
}
