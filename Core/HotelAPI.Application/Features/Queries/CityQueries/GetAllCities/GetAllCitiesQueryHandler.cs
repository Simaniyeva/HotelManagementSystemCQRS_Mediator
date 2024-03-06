using MediatR;

namespace HotelAPI.Application.Features.Queries.CityQueries.GetAllCities;

public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQueryRequest, GetAllCitiesQueryResponse>
{
    private readonly ICityReadRepository _cityReadRepository;
    private readonly IMapper _mapper;

    public GetAllCitiesQueryHandler(ICityReadRepository cityReadRepository, IMapper mapper)
    {
        _cityReadRepository = cityReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllCitiesQueryResponse> Handle(GetAllCitiesQueryRequest request, CancellationToken cancellationToken)
    {
        List<City> cities = request.isDeleted
            ? await _cityReadRepository.GetAllAsync()
            : await _cityReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active);
        if (cities is null)
        {
            return new GetAllCitiesQueryResponse
            {
                Result = new ErrorDataResult<List<CityGetDto>>(Messages.NotFound(Messages.City))
            };

        }
        return new GetAllCitiesQueryResponse
        {
            Result = new SuccessDataResult<List<CityGetDto>>(_mapper.Map<List<CityGetDto>>(cities))
        };
    }
}
