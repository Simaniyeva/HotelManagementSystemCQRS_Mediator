namespace HotelAPI.Application.DTOs.CountryDtos;

public class CountryGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Continent { get; set; }

    //Relations
    public List<CityGetDto> Cities { get; set; }

}
