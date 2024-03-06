namespace HotelAPI.Application.Features.Commands.EquipmentCommands.UpdateEquipment;

public class UpdateEquipmentCommandResponse : IRequest<UpdateEquipmentCommandRequest>
{

    public DataResult<EquipmentUpdateDto> Result { get; set; }

}
