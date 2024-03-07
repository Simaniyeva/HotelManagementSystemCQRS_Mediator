namespace HotelAPI.Application.Features.Queries.HotelQueries.GetAllDetailsOfHotels;

public class GetAllDetailsOfHotelsQueryHandler : IRequestHandler<GetAllDetailsOfHotelsQueryRequest, GetAllDetailsOfHotelsQueryResponse>
{
    private readonly IHotelReadRepository _hotelReadRepository;
    private readonly IMapper _mapper;

    public GetAllDetailsOfHotelsQueryHandler(IHotelReadRepository hotelReadRepository, IMapper mapper)
    {
        _hotelReadRepository = hotelReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllDetailsOfHotelsQueryResponse> Handle(GetAllDetailsOfHotelsQueryRequest request, CancellationToken cancellationToken)
    {
        List<Hotel> hotels = request.isDeleted
            ? await _hotelReadRepository.GetAllCityDetailsAsync()
            : await _hotelReadRepository.GetAllCityDetailsAsync(c => c.entityStatus == EntityStatus.Active);
        if (hotels is null)
        {
            return new GetAllDetailsOfHotelsQueryResponse
            {
                Result = new ErrorDataResult<List<HotelGetDto>>(Messages.NotFound(Messages.Hotel))
            };

        }
        return new GetAllDetailsOfHotelsQueryResponse
        {
            Result = new SuccessDataResult<List<HotelGetDto>>(_mapper.Map<List<HotelGetDto>>(hotels))
        };
    }
}
