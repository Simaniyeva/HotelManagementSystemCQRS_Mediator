namespace HotelAPI.Application.Features.Commands.EquipmentCommands.CreateEquipment;

public record CreateEquipmentCommandRequest:IRequest<CreateEquipmentCommandResponse>
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}
