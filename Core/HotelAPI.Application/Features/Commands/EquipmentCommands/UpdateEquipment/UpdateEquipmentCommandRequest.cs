namespace HotelAPI.Application.Features.Commands.EquipmentCommands.UpdateEquipment;

public class UpdateEquipmentCommandRequest:IRequest<UpdateEquipmentCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}
