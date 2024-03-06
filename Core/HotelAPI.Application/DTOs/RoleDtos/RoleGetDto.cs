namespace HotelAPI.Application.DTOs.RoleDtos;

public class RoleGetDto : IDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<UserGetDto> Users { get; set; }
}