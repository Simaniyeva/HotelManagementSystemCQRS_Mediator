namespace HotelAPI.Application.Features.Commands.RoomTypeCommands.CreateRoomType;

public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommandRequest, CreateRoomTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IRoomTypeWriteRepository _roomTypeWriteRepository;

    public CreateRoomTypeCommandHandler(IMapper mapper, IRoomTypeWriteRepository roomTypeWriteRepository)
    {
        _mapper = mapper;
        _roomTypeWriteRepository = roomTypeWriteRepository;
    }

    public async Task<CreateRoomTypeCommandResponse> Handle(CreateRoomTypeCommandRequest request, CancellationToken cancellationToken)
    {
        RoomType roomType = _mapper.Map<RoomType>(request);
        await _roomTypeWriteRepository.CreateAsync(roomType);
        int result = await _roomTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new CreateRoomTypeCommandResponse
            {
                Result = new ErrorDataResult<RoomTypePostDto>(Messages.NotCreated(Messages.RoomType))
            };
        }

        return new CreateRoomTypeCommandResponse
        {
            Result = new SuccessDataResult<RoomTypePostDto>(_mapper.Map<RoomTypePostDto>(roomType))
        };
    }
}
