namespace HotelAPI.Application.Features.Queries.CountryQueries.GetAllDetailsOfCountry;

public class GetAllDetailsOfCountriesQueryHandler:IRequestHandler<GetAllDetailsOfCountriesQueryRequest, GetAllDetailsOfCountriesQueryResponse>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly IMapper _mapper;

    public GetAllDetailsOfCountriesQueryHandler(ICountryReadRepository countryReadRepository, IMapper mapper)
    {
        _countryReadRepository = countryReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllDetailsOfCountriesQueryResponse> Handle(GetAllDetailsOfCountriesQueryRequest request, CancellationToken cancellationToken)
    {
        List<Country> countries = request.isDeleted
            ? await _countryReadRepository.GetAllDetailsOfCountries()
            : await _countryReadRepository.GetAllDetailsOfCountries(c => c.entityStatus == EntityStatus.Active);
        if (countries is null)
        {
            return new GetAllDetailsOfCountriesQueryResponse
            {
                Result = new ErrorDataResult<List<CountryGetDto>>(Messages.NotFound(Messages.Country))
            };

        }
        return new GetAllDetailsOfCountriesQueryResponse
        {
            Result = new SuccessDataResult<List<CountryGetDto>>(_mapper.Map<List<CountryGetDto>>(countries))
        };
    }
}
