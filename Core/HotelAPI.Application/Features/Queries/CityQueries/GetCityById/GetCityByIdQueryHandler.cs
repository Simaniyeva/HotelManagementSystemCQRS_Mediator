
namespace HotelAPI.Application.Features.Queries.CityQueries.GetCityById;

public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQueryRequest, GetCityByIdQueryResponse>
{
    readonly ICityReadRepository _cityReadRepository;
    readonly IMapper _mapper;

    public GetCityByIdQueryHandler(ICityReadRepository cityReadRepository, IMapper mapper)
    {
        _cityReadRepository = cityReadRepository;
        _mapper = mapper;
    }

    public Task<GetCityByIdQueryResponse> Handle(GetCityByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    //public async Task<GetCityByIdQueryResponse> Handle(GetCityByIdQueryRequest request, CancellationToken cancellationToken)
    //{
    //    City city = await _cityReadRepository.GetAsync(c => c.Id == request.Id && c.entityStatus=request.isDeleted);
    //    if (city is null)
    //    {
    //        return new GetCityByIdQueryResponse
    //        {
    //            Result = new ErrorDataResult<CityGetDto>(Messages.NotFound(Messages.City))
    //        };

    //    }
    //    return new GetCityByIdQueryResponse
    //    {
    //        Result = new SuccessDataResult<CityGetDto>(_mapper.Map<CityGetDto>(city))
    //    };
    //}
}
