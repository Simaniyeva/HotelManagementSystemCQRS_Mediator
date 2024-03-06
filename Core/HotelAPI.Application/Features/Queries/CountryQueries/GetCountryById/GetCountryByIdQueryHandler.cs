using HotelAPI.Application.Features.Queries.CityQueries.GetCityById;

namespace HotelAPI.Application.Features.Queries.CountryQueries.GetCountryById;

public class GetCountryByIdQueryHandler:IRequestHandler<GetCountryByIdQueryRequest,GetCountryByIdQueryResponse>
{

    readonly ICountryReadRepository _countryReadRepository;
    readonly IMapper _mapper;

    public GetCountryByIdQueryHandler(ICountryReadRepository countryReadRepository, IMapper mapper)
    {
        _countryReadRepository = countryReadRepository;
        _mapper = mapper;
    }

    public async Task<GetCountryByIdQueryResponse> Handle(GetCountryByIdQueryRequest request, CancellationToken cancellationToken)
    {
        Country country = await _countryReadRepository.GetAsync(c => c.Id == request.Id, request.Includes);
        if (country is null)
        {
            return new GetCountryByIdQueryResponse
            {
                Result = new ErrorDataResult<CountryGetDto>(Messages.NotFound(Messages.Country))
            };

        }
        return new GetCountryByIdQueryResponse
        {
            Result = new SuccessDataResult<CountryGetDto>(_mapper.Map<CountryGetDto>(country))
        };
    }

}
