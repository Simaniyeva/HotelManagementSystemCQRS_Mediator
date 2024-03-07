namespace HotelAPI.Application.Features.Queries.HotelQueries.GetAllHotels;

public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQueryRequest, GetAllHotelsQueryResponse>
{
    private readonly IHotelReadRepository _hotelReadRepository;
    private readonly IMapper _mapper;

    public GetAllHotelsQueryHandler(IHotelReadRepository repository, IMapper mapper)
    {
        _hotelReadRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAllHotelsQueryResponse> Handle(GetAllHotelsQueryRequest request, CancellationToken cancellationToken)
    {
        List<Hotel> hotels = request.isDeleted
              ? await _hotelReadRepository.GetAllAsync()
              : await _hotelReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active);
        if (hotels is null)
        {
            return new GetAllHotelsQueryResponse
            {
                Result = new ErrorDataResult<List<HotelGetDto>>(Messages.NotFound(Messages.Hotel))
            };

        }
        return new GetAllHotelsQueryResponse
        {
            Result = new SuccessDataResult<List<HotelGetDto>>(_mapper.Map<List<HotelGetDto>>(hotels))
        };
    }
}