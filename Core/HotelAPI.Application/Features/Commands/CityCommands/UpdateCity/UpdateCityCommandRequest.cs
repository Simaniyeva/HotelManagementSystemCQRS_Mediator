using MediatR;

namespace HotelAPI.Application.Features.Commands.CityCommands.UpdateCity;

public class UpdateCityCommandRequest:IRequest<UpdateCityCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PostalCode { get; set; }
    //Relations 
    public int CountryId { get; set; }
}
