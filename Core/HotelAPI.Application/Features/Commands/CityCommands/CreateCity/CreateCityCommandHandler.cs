namespace HotelAPI.Application.Features.Commands.CityCommands.CreateCity;

public class CreateCityCommandHandler : IRequestHandler<CreateCityCommandRequest, CreateCityCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICityWriteRepository _cityWriteRepository;
    public CreateCityCommandHandler(IMapper mapper, ICityWriteRepository cityWriteRepository)
    {
        _mapper = mapper;
        _cityWriteRepository = cityWriteRepository;
    }

    public async Task<CreateCityCommandResponse> Handle(CreateCityCommandRequest request, CancellationToken cancellationToken)
    {
        City city = _mapper.Map<City>(request);
        await _cityWriteRepository.CreateAsync(city);
        int result = await _cityWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new CreateCityCommandResponse
            {
                Result = new ErrorDataResult<CityPostDto>(Messages.NotCreated(Messages.City))
            };
        }

        return new CreateCityCommandResponse
        {
            Result = new SuccessDataResult<CityPostDto>(_mapper.Map<CityPostDto>(city))
        };
    }
}



