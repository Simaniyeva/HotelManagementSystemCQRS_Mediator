namespace HotelAPI.Application.Features.Queries.CityQueries.GetAllDetailsOfCities;

public class GetAllDetailsOfCitiesQueryHandler : IRequestHandler<GetAllDetailsOfCitiesQueryRequest, GetAllDetailsOfCitiesQueryResponse>
{
    private readonly ICityReadRepository _cityReadRepository;
    private readonly IMapper _mapper;

    public GetAllDetailsOfCitiesQueryHandler(ICityReadRepository cityReadRepository, IMapper mapper)
    {
        _cityReadRepository = cityReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllDetailsOfCitiesQueryResponse> Handle(GetAllDetailsOfCitiesQueryRequest request, CancellationToken cancellationToken)
    {
        List<City> cities = request.isDeleted
            ? await _cityReadRepository.GetAllCityDetailsAsync()
            : await _cityReadRepository.GetAllCityDetailsAsync(c => c.entityStatus == EntityStatus.Active);
        if (cities is null)
        {
            return new GetAllDetailsOfCitiesQueryResponse
            {
                Result = new ErrorDataResult<List<CityGetDto>>(Messages.NotFound(Messages.City))
            };

        }
        return new GetAllDetailsOfCitiesQueryResponse
        {
            Result = new SuccessDataResult<List<CityGetDto>>(_mapper.Map<List<CityGetDto>>(cities))
        };
    }
}
