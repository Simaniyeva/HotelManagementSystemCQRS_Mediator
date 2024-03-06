using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.CountryDtos;

public class CountryUpdateDto : IDto, IMapTo<Country>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Continent { get; set; }
}