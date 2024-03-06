namespace HotelAPI.Application.Features.Commands.CityCommands.CreateCity;

public class CreateCityCommandRequest : IRequest<CreateCityCommandResponse>
{
    public string Name { get; set; }
    public string PostalCode { get; set; }

    //Relations 
    public int CountryId { get; set; }
}
