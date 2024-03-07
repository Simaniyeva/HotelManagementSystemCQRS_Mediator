namespace HotelAPI.Application.Features.Commands.HotelCommands.DeleteHotel;

public record DeleteHotelCommandRequest(int id):IRequest<DeleteHotelCommandResponse>;
