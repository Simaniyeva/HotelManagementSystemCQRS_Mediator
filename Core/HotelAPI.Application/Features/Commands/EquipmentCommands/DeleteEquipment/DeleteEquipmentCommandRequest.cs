using HotelAPI.Application.Features.Commands.CountryCommands.DeleteCountry;

namespace HotelAPI.Application.Features.Commands.EquipmentCommands.DeleteEquipment;

public class DeleteEquipmentCommandRequest : IRequest<DeleteEquipmentCommandResponse>
{
    public int Id { get; set; }

}

