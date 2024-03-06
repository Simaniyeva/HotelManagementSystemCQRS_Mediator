namespace HotelAPI.Application.Features.Commands.CountryCommands.UpdateCountry;

public class UpdateCountryCommandRequest:IRequest<UpdateCountryCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Continent { get; set; }
}
