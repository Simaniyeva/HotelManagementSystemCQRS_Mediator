namespace HotelAPI.Application.Features.Commands.RoomTypeCommands.UpdateRoomType;

public class UpdateRoomTypeCommandRequest : IRequest<UpdateRoomTypeCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
