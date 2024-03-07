namespace HotelAPI.Application.Features.Commands.RoomTypeCommands.UpdateRoomType;

public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommandRequest, UpdateRoomTypeCommandResponse>
{
    private readonly IRoomTypeWriteRepository _roomTypeWriteRepository;
    private readonly IRoomTypeReadRepository _roomTypeReadRepository;
    private IMapper _mapper;

    public UpdateRoomTypeCommandHandler(IRoomTypeWriteRepository roomTypeWriteRepository, IMapper mapper, IRoomTypeReadRepository roomTypeReadRepository)
    {
        _roomTypeWriteRepository = roomTypeWriteRepository;
        _mapper = mapper;
        _roomTypeReadRepository = roomTypeReadRepository;
    }

    public async Task<UpdateRoomTypeCommandResponse> Handle(UpdateRoomTypeCommandRequest request, CancellationToken cancellationToken)
    {
        RoomType roomType = await _roomTypeReadRepository.GetAsync(c => c.Id == request.Id && c.entityStatus == EntityStatus.Active);
        roomType = _mapper.Map<RoomType>(request);
        _roomTypeWriteRepository.Update(roomType);
        int result = await _roomTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new UpdateRoomTypeCommandResponse
            {
                Result = new ErrorDataResult<RoomTypeUpdateDto>(Messages.NotUpdated(Messages.RoomType))
            };
        }

        return new UpdateRoomTypeCommandResponse
        {
            Result = new SuccessDataResult<RoomTypeUpdateDto>(_mapper.Map<RoomTypeUpdateDto>(roomType))
        };
    }
}
