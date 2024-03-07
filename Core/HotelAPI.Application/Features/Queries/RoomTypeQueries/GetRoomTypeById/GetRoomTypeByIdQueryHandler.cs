
namespace HotelAPI.Application.Features.Queries.RoomTypeQueries.GetRoomTypeById;

public class GetRoomTypeByIdQueryHandler : IRequestHandler<GetRoomTypeByIdQueryRequest, GetRoomTypeByIdQueryResponse>
{
    private readonly IRoomTypeReadRepository _roomTypeReadRepository;
    private readonly IMapper _mapper;

    public GetRoomTypeByIdQueryHandler(IRoomTypeReadRepository roomTypeReadRepository, IMapper mapper)
    {
        _roomTypeReadRepository = roomTypeReadRepository;
        _mapper = mapper;
    }

    public Task<GetRoomTypeByIdQueryResponse> Handle(GetRoomTypeByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
