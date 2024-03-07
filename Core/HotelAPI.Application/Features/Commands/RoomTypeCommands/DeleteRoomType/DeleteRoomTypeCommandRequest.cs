namespace HotelAPI.Application.Features.Commands.RoomTypeCommands.DeleteRoomType;

public record DeleteRoomTypeCommandRequest(int id):IRequest<DeleteRoomTypeCommandResponse>;
