using HotelAPI.Application.Features.Commands.CityCommands.CreateCity;

namespace HotelAPI.Application.Features.Commands.CountryCommands.CreateCountry;

public class CreateCountryCommandRequest:IRequest<CreateCountryCommandResponse>
{
    public string Name { get; set; }
    public string Continent { get; set; }
}
