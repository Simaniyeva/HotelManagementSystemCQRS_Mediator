
using HotelAPI.Application.Features.Queries.CityQueries.GetAllDetailsOfCities;

namespace HotelAPI.Application.Features.Queries.RoomTypeQueries.GetAllDetailsOfRoomTypes;

public class GetAllDetailsOfRoomTypesQueryHandler : IRequestHandler<GetAllDetailsOfRoomTypesQueryRequest, GetAllDetailsOfRoomTypesQueryResponse>
{
    private readonly IRoomTypeReadRepository _roomTypeReadRepository;
    private readonly IMapper _mapper;

    public GetAllDetailsOfRoomTypesQueryHandler(IRoomTypeReadRepository roomTypeReadRepository, IMapper mapper)
    {
        _roomTypeReadRepository = roomTypeReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllDetailsOfRoomTypesQueryResponse> Handle(GetAllDetailsOfRoomTypesQueryRequest request, CancellationToken cancellationToken)
    {
        List<RoomType> roomtypes = request.isDeleted
          ? await _roomTypeReadRepository.GetAllRoomTypesDetailsAsync()
          : await _roomTypeReadRepository.GetAllRoomTypesDetailsAsync(c => c.entityStatus == EntityStatus.Active);
        if (roomtypes is null)
        {
            return new GetAllDetailsOfRoomTypesQueryResponse
            {
                Result = new ErrorDataResult<List<RoomTypeGetDto>>(Messages.NotFound(Messages.RoomType))
            };

        }
        return new GetAllDetailsOfRoomTypesQueryResponse
        {
            Result = new SuccessDataResult<List<RoomTypeGetDto>>(_mapper.Map<List<RoomTypeGetDto>>(roomtypes))
        };
    }
}
