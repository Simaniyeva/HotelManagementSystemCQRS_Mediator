namespace HotelAPI.Application.Features.Queries.CountryQueries.GetAllCountry;

public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQueryRequest, GetAllCountryQueryResponse>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly IMapper _mapper;

    public GetAllCountryQueryHandler(ICountryReadRepository countryReadRepository, IMapper mapper)
    {
        _countryReadRepository = countryReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllCountryQueryResponse> Handle(GetAllCountryQueryRequest request, CancellationToken cancellationToken)
    {

        List<Country> countries = request.isDeleted
            ? await _countryReadRepository.GetAllAsync()
            : await _countryReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active);
        if (countries is null)
        {
            return new GetAllCountryQueryResponse
            {
                Result = new ErrorDataResult<List<CountryGetDto>>(Messages.NotFound(Messages.Country))
            };

        }
        return new GetAllCountryQueryResponse
        {
            Result = new SuccessDataResult<List<CountryGetDto>>(_mapper.Map<List<CountryGetDto>>(countries))
        };

    }
}
