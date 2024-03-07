namespace HotelAPI.Application.Features.Commands.RoomTypeCommands.DeleteRoomType;

public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommandRequest, DeleteRoomTypeCommandResponse>
{
    private readonly IRoomTypeWriteRepository _roomTypeWriteRepository;
    private readonly IRoomTypeReadRepository _roomTypeReadRepository;

    public DeleteRoomTypeCommandHandler(IRoomTypeWriteRepository roomTypeWriteRepository, IRoomTypeReadRepository roomTypeReadRepository)
    {
        _roomTypeWriteRepository = roomTypeWriteRepository;
        _roomTypeReadRepository = roomTypeReadRepository;
    }

    public async Task<DeleteRoomTypeCommandResponse> Handle(DeleteRoomTypeCommandRequest request, CancellationToken cancellationToken)
    {
        RoomType roomType = await _roomTypeReadRepository.GetAsync(c=>c.Id==request.id && c.entityStatus == EntityStatus.Active);
        if (roomType is not null)
        {
            roomType.entityStatus = EntityStatus.InActive;
            _roomTypeWriteRepository.Update(roomType);
            await _roomTypeWriteRepository.SaveAsync();
            return new DeleteRoomTypeCommandResponse
            {
                Success = true

            };
        }

        return new DeleteRoomTypeCommandResponse
        {
            Success = false,
            ErrorMessage = "RoomType is not found or not active."
        };

    }
}
