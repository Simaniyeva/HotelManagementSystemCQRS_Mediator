namespace HotelAPI.Application.Features.Commands.CityCommands.DeleteCity;

public class DeleteCityCommandRequest : IRequest<DeleteCityCommandResponse>
{
    public int Id { get; set; }
}
