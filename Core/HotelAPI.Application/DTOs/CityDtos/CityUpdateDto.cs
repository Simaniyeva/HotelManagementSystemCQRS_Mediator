using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.CityDtos;

public class CityUpdateDto : IDto, IMapTo<City>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PostalCode { get; set; }
    //Relations 
    public int CountryId { get; set; }
}