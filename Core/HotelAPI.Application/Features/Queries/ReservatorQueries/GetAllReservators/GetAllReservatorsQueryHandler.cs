namespace HotelAPI.Application.Features.Queries.ReservatorQueries.GetAllReservators;

public class GetAllReservatorsQueryHandler : IRequestHandler<GetAllReservatorsQueryRequest, GetAllReservatorsQueryResponse>
{
    private readonly IReservatorReadRepository _reservatorReadRepository;
    private readonly IMapper _mapper;

    public GetAllReservatorsQueryHandler(IReservatorReadRepository reservatorReadRepository, IMapper mapper)
    {
        _reservatorReadRepository = reservatorReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllReservatorsQueryResponse> Handle(GetAllReservatorsQueryRequest request, CancellationToken cancellationToken)
    {
        List<Reservator> reservators= await _reservatorReadRepository.GetAllAsync();
        if (reservators is null)
        {
            return new GetAllReservatorsQueryResponse
            {
                Result = new ErrorDataResult<List<ReservatorGetDto>>(Messages.NotFound(Messages.Reservator))
            };

        }
        return new GetAllReservatorsQueryResponse
        {
            Result = new SuccessDataResult<List<ReservatorGetDto>>(_mapper.Map<List<ReservatorGetDto>>(reservators))
        };
    }
}
