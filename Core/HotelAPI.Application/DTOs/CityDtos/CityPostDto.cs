using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.CityDtos;

public class CityPostDto :IDto , IMapTo<City>
{
    public string Name { get; set; }
    public string PostalCode { get; set; }

    //Relations 
    public int CountryId { get; set; }

}
