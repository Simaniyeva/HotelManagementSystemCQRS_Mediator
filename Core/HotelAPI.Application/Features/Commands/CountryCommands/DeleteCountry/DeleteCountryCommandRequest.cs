namespace HotelAPI.Application.Features.Commands.CountryCommands.DeleteCountry;

public partial class DeleteCountryCommandRequest : IRequest<DeleteCountryCommandResponse>
{
    public int Id { get; set; }
}