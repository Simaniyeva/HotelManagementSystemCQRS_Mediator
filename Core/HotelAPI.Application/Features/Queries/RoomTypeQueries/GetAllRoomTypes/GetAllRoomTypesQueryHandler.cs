namespace HotelAPI.Application.Features.Queries.RoomTypeQueries.GetAllRoomTypes;

public class GetAllRoomTypesQueryHandler : IRequestHandler<GetAllRoomTypesQueryRequest, GetAllRoomTypesQueryResponse>
{
    private readonly IRoomTypeReadRepository _roomTypeReadRepository;
    private readonly IMapper _mapper;

    public GetAllRoomTypesQueryHandler(IRoomTypeReadRepository roomTypeReadRepository, IMapper mapper)
    {
        _roomTypeReadRepository = roomTypeReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllRoomTypesQueryResponse> Handle(GetAllRoomTypesQueryRequest request, CancellationToken cancellationToken)
    {
        List<RoomType> roomTypes = request.isDeleted
            ? await _roomTypeReadRepository.GetAllAsync()
            : await _roomTypeReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active);
        if (roomTypes is null)
        {
            return new GetAllRoomTypesQueryResponse
            {
                Result = new ErrorDataResult<List<RoomTypeGetDto>>(Messages.NotFound(Messages.RoomType))
            };

        }
        return new GetAllRoomTypesQueryResponse
        {
            Result = new SuccessDataResult<List<RoomTypeGetDto>>(_mapper.Map<List<RoomTypeGetDto>>(roomTypes))
        };
    }
}
