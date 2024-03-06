using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.CountryDtos;

public class CountryPostDto : IDto, IMapTo<Country>
{
    public string Name { get; set; }
    public string Continent { get; set; }

    //Relations
}
