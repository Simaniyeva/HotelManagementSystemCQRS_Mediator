namespace HotelAPI.Application.Features.Commands.RoomTypeCommands.CreateRoomType;

public class CreateRoomTypeCommandRequest:IRequest<CreateRoomTypeCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }

}
