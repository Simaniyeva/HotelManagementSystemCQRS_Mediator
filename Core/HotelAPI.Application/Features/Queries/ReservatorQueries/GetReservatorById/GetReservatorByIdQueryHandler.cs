namespace HotelAPI.Application.Features.Queries.ReservatorQueries.GetReservatorById;

public class GetReservatorByIdQueryHandler : IRequestHandler<GetReservatorByIdQueryRequest, GetReservatorByIdQueryResponse>
{
    private readonly IReservatorReadRepository _reservatorReadRepository;
    private readonly IMapper _mapper;

    public GetReservatorByIdQueryHandler(IReservatorReadRepository reservatorReadRepository, IMapper mapper)
    {
        _reservatorReadRepository = reservatorReadRepository;
        _mapper = mapper;
    }

    public async Task<GetReservatorByIdQueryResponse> Handle(GetReservatorByIdQueryRequest request, CancellationToken cancellationToken)
    {
        Reservator reservator = await _reservatorReadRepository.GetAsync(c => c.Id == request.id);
        if (reservator is null)
        {
            return new GetReservatorByIdQueryResponse
            {
                Result = new ErrorDataResult<ReservatorGetDto>(Messages.NotFound(Messages.Reservator))
            };

        }
        return new GetReservatorByIdQueryResponse
        {
            Result = new SuccessDataResult<ReservatorGetDto>(_mapper.Map<ReservatorGetDto>(reservator))
        };
    }
}